using CashBackApi.Services.Services;
using CashBackApi.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace CashBackApi.Services
{
    public static class DependencyInjection
    {
        public static void AddCashBackServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICashBackService, CashBackService>();
            services.AddScoped<IDicoService, DicoService>();
            services.AddScoped<ISmsService, SmsService>();
        }
    }
}
