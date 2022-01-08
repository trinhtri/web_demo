using Microsoft.EntityFrameworkCore;
using DGod.SuparCar.Application.Interfaces.Shared;
using DGod.SuparCar.Application.Settings;
using DGod.SuparCar.Infrastructure.DbContexts;
using DGod.SuparCar.Infrastructure.Shared.Services;

namespace DGod.SuparCar.Host.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddPersistenceContexts(configuration);
        }

        private static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("ConnectionStrings").Get<SqlSettings>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.ApplicationConnection));
        }
        
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, SystemDateTimeService>();
        }
    }
}