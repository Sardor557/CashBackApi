using AsbtCore.UtilsV2;
using CashBackApi.Database;
using CashBackApi.Models;
using CashBackApi.Shared.Interfaces;
using CashBackApi.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CashBackApi.Services.Services
{
    public sealed class CashBackService : ICashBackService
    {
        private readonly ILogger<CashBackService> logger;
        private readonly MyDbContext db;
        private readonly IHttpContextAccessorExtensions accessor;

        public CashBackService(ILogger<CashBackService> logger, MyDbContext db, IHttpContextAccessorExtensions accessor)
        {
            this.logger = logger;
            this.db = db;
            this.accessor = accessor;
        }

        public async ValueTask<AnswereBasic> ChangeCashbackAsync(viCashback cashback)
        {
            var validate = cashback.Validate();
            if (validate.AnswerId != 0)
                return new AnswereBasic(validate.AnswerId, validate.AnswerMessage);

            var tran = await db.Database.BeginTransactionAsync();
            try
            {
                int userId = accessor.GetId();

                var ck = await db.tbCashBacks.FirstOrDefaultAsync(x => x.UserId == cashback.UserId);
                ck.TotalBalance = ck.TotalBalance + cashback.Income - cashback.Outcome;
                ck.UpdateDate = DateTime.Now;
                ck.UpdateUser = userId;

                var balance = new tbCashBackBalance();
                balance.CashBackId = ck.Id;
                balance.Income = cashback.Income;
                balance.Outcome = cashback.Outcome;
                balance.CreateDate = DateTime.Now;
                balance.CreateUser = userId;
                balance.Status = 1;

                await db.tbCashBackBalances.AddAsync(balance);
                await db.SaveChangesAsync();
                await tran.CommitAsync();

                return new AnswereBasic(0, "");
            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
                logger.LogError($"CashBackService.IncreaseCashbackAsync error: {ex.GetAllMessages()}");
                return new AnswereBasic(600, "Ошибка системы");
            }
        }

        public async Task CreateCashbackAsync(int userId)
        {
            var tran = await db.Database.BeginTransactionAsync();
            try
            {
                var ck = new tbCashBack();
                ck.Id = userId;
                ck.TotalBalance = 0;
                ck.CreateDate = DateTime.Now;
                ck.CreateUser = accessor.GetId();
                ck.Status = 1;

                await db.tbCashBacks.AddAsync(ck);
                await db.SaveChangesAsync();
                await tran.CommitAsync();
            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
                logger.LogError($"CashBackService.CreateCashbackAsync error: {ex.GetAllMessages()}");
            }
        }
    }
}
