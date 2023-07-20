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
    public sealed class DicoService : IDicoService
    {
        private readonly ILogger<DicoService> logger;
        private readonly MyDbContext db;

        public DicoService(ILogger<DicoService> logger, MyDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        public async ValueTask<Answer<spStatus[]>> GetStatusesAsync()
        {
            try
            {
                var sts = await db.spStatuses.AsNoTracking().ToArrayAsync();
                return new Answer<spStatus[]>(sts);
            }
            catch (Exception ex)
            {
                logger.LogError($"DicoService.GetStatusesAsync error: {ex.GetAllMessages()}");
                return new Answer<spStatus[]>(600, "Ошибка системы");
            }
        }

        public async ValueTask<Answer<spUserType[]>> GetUserTypesAsync()
        {
            try
            {
                var sts = await db.spUserTypes.AsNoTracking().ToArrayAsync();
                return new Answer<spUserType[]>(sts);
            }
            catch (Exception ex)
            {
                logger.LogError($"DicoService.GetUserTypesAsync error: {ex.GetAllMessages()}");
                return new Answer<spUserType[]>(600, "Ошибка системы");
            }
        }
    }
}
