using AsbtCore.UtilsV2;
using CashBackApi.Database;
using CashBackApi.Models;
using CashBackApi.Shared.Interfaces;
using CashBackApi.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CashBackApi.Services.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IConfiguration conf;
        private readonly MyDbContext db;
        private readonly IHttpContextAccessorExtensions accessor;
        private readonly ILogger<UserService> logger;
        private readonly ISmsService smsService;

        public UserService(IConfiguration conf, MyDbContext db, IHttpContextAccessorExtensions accessor, ILogger<UserService> logger, ISmsService smsService)
        {
            this.conf = conf;
            this.db = db;
            this.accessor = accessor;
            this.logger = logger;
            this.smsService = smsService;
        }

        private viUser GetToken(tbUser res)
        {
            var SecretStr = conf["SystemParams:PrivateKeyString"];
            var key = Encoding.ASCII.GetBytes(SecretStr);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                           {
                               new Claim(ClaimTypes.Sid, res.Id.ToString()),
                               new Claim(ClaimTypes.Name, $"{res.FullName}"),
                               new Claim(ClaimTypes.NameIdentifier, res.Login.ToString()),
                               new Claim(ClaimTypes.Role, res.UserTypeId.ToString()),
                               new Claim("UserTypeId", res.UserTypeId.ToString()),
                           }),
                Expires = DateTime.Now.AddDays(365),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var usr = new viUser();
            usr.Id = res.Id;
            usr.Token = tokenHandler.WriteToken(token);
            usr.Login = res.Login;
            usr.FIO = res.FullName;
            usr.TypeId = res.UserTypeId;

            return usr;
        }

        private int GetRandomVerifiedCode()
        {
            var rnd = new Random();
            return rnd.Next(1000, 9999);
        }

        public async ValueTask<Answer<viUser>> AuthenticateAsync(viAuthenticateModel model, string ip)
        {
            var validate = model.Validate();
            if (validate.AnswerId != 0)
                return new Answer<viUser>(validate.AnswerId, validate.AnswerMessage);

            try
            {
                var hash = CHash.EncryptMD5(model.Password);
                var res = await db.tbUsers
                                  .AsNoTracking()
                                  .Where(x => x.Login == model.Login && x.Password == hash)
                                  .FirstOrDefaultAsync();

                if (res == null)
                {
                    logger.LogError($"Пользователь не найден {model} Ip:{ip}");
                    return new Answer<viUser>(204, "Неправильный логин или пароль");
                }

                return new Answer<viUser>(GetToken(res));
            }
            catch (Exception ex)
            {
                logger.LogError($"UserService.AuthenticateAsync error: {ex.GetAllMessages()}");
                return new Answer<viUser>(600, "Системная ошибка");
            }
        }

        public async ValueTask<Answer<viUser>> CreateUserAsync(viUserCreate create)
        {
            int userId = accessor.GetId();
            var validate = create.Validate();
            if (validate.AnswerId != 0)
                return new Answer<viUser>(validate.AnswerId, validate.AnswerMessage);

            var tran = await db.Database.BeginTransactionAsync();
            try
            {
                int code = GetRandomVerifiedCode();
                var user = await db.tbUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Phone == create.Phone);
                if (user is not null)                
                    return await OnUserExistAsync(code, user);

                user = new tbUser();
                user.Phone = create.Phone;
                user.FullName = create.FullName;
                user.CreateDate = DateTime.Now;
                user.CreateUser = userId;
                user.Status = 1;

                await db.tbUsers.AddAsync(user);
                await db.SaveChangesAsync();

                var verificate = new tbSmsVerification();
                verificate.Phone = create.Phone;
                verificate.Code = code;
                verificate.IsVerificated = false;
                verificate.CreateDate = DateTime.Now;
                verificate.CreateUser = userId;
                verificate.Status = 1;

                await db.tbSmsVerifications.AddAsync(verificate);
                await db.SaveChangesAsync();
                await tran.CommitAsync();

                var sms = await smsService.SendSmsAsync(new viSms { Code = code, Phone = create.Phone });

                return new Answer<viUser>(sms.AnswerId, sms.AnswerMessage);

            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
                logger.LogError($"UserService.CreateUserAsync error: {ex.GetAllMessages()}");
                return new Answer<viUser>(204, "Системная ошибка");
            }
        }

        private async ValueTask<Answer<viUser>> OnUserExistAsync(int code, tbUser user)
        {
            var tran = db.Database.CurrentTransaction;

            var sendSms = await smsService.SendSmsAsync(new viSms { Phone = user.Phone, Code = code });
            if (sendSms.AnswerId != 0)
            {
                await tran.RollbackAsync();
                return new Answer<viUser>(204, sendSms.AnswerMessage);
            }

            var verificate = new tbSmsVerification();
            verificate.UserId = user.Id;
            verificate.Code = code;
            verificate.IsVerificated = false;
            verificate.Status = 1;
            verificate.CreateDate = DateTime.Now;
            verificate.CreateUser = accessor.GetId();
            await db.tbSmsVerifications.AddAsync(verificate);

            await db.SaveChangesAsync();
            await tran.CommitAsync();

            return new Answer<viUser>(0, "Такой пользователь существует, но не верефицирован, отправлен СМС с кодом подтверждения");
        }
    }
}
