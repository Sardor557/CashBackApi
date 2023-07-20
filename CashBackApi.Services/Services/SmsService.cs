using AsbtCore.UtilsV2;
using CashBackApi.Database;
using CashBackApi.Shared.Interfaces;
using CashBackApi.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CashBackApi.Services.Services
{
    public sealed class SmsService : ISmsService
    {
        private readonly ILogger<SmsService> logger;
        private readonly IConfiguration conf;
        private readonly HttpClient client;
        private readonly MyDbContext db;
        private readonly ICashBackService cashBackService;

        public SmsService(ILogger<SmsService> logger, IConfiguration conf, MyDbContext db, ICashBackService cashBackService)
        {
            this.logger = logger;
            this.conf = conf;
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.db = db;
            this.cashBackService = cashBackService;
        }

        public async ValueTask<AnswereBasic> SendSmsAsync(viSms sms)
        {
            try
            {
                var req = new HttpRequestMessage(HttpMethod.Post, conf["SMSUrl"]);
                req.Content = new StringContent(sms.ToJson(), Encoding.UTF8, "application/json");
                var res = await client.SendAsync(req);
                if (res.IsSuccessStatusCode)
                    return new AnswereBasic(0, $"Отправлен СМС на номер: {sms.Phone}");

                return new AnswereBasic(204, $"Ошибка при отправке смс на номер: {sms.Phone}");
            }
            catch (Exception ex)
            {
                logger.LogError($"SmsService.SendSmsAsync error: {ex.GetAllMessages()}");
                return new AnswereBasic(600, "Ошибка системы");
            }
        }

        public async ValueTask<AnswereBasic> ConfirmSmsAsync(viSms sms)
        {
            var tran = await db.Database.BeginTransactionAsync();
            try
            {
                var ver = await db.tbSmsVerifications.FirstOrDefaultAsync(x => x.Phone == sms.Phone && sms.Code == sms.Code && !x.IsVerificated);

                if (ver is null)
                {
                    await tran.RollbackAsync();
                    return new AnswereBasic(204, "Введен неправильный код подтверждения");
                }

                ver.IsVerificated = true;

                await cashBackService.CreateCashbackAsync(ver.UserId);    
                await db.SaveChangesAsync();

                return new AnswereBasic(0, "");
            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
                logger.LogError($"SmsService.ConfirmSmsAsync error: {ex.GetAllMessages()}");
                return new AnswereBasic(600, "Ошибка системы");
            }
        }
    }
}
