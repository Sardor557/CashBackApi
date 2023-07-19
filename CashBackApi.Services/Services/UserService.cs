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
using System.Collections.Generic;
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

        public UserService(IConfiguration conf, MyDbContext db, IHttpContextAccessorExtensions accessor, ILogger<UserService> logger)
        {
            this.conf = conf;
            this.db = db;
            this.accessor = accessor;
            this.logger = logger;
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

        public async ValueTask<Answer<viUser>> AuthenticateAsync(viAuthenticateModel model, string ip)
        {
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

                return new Answer<viUser>(0, "", "", GetToken(res));
            }
            catch (Exception ex)
            {
                logger.LogError($"UserService.AuthenticateAsync error: {ex.GetAllMessages()}");
                return new Answer<viUser>(204, "Системная ошибка");
            }
        }
    }
}
