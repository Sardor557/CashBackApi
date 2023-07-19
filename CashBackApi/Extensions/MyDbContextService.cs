using CashBackApi.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashBackApi.Extensions
{
    public static class MyDbContextService
    {
        public static void AddMyDatabaseService(this IServiceCollection services, IConfiguration conf)
        {
            var connStr = conf.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyDbContext>(o =>
            {
                o.UseNpgsql(connStr, b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                   .EnableDetailedErrors()
                   .EnableSensitiveDataLogging()
                   .UseSnakeCaseNamingConvention();
            });
        }

        public static void UpdateMigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                        .GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MyDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
