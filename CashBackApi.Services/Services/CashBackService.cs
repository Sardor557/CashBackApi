using CashBackApi.Database;
using CashBackApi.Shared.Interfaces;
using Microsoft.Extensions.Logging;

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

        
    }
}
