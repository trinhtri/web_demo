using Microsoft.EntityFrameworkCore;
using DGod.SuparCar.Application.Interfaces.Shared;
using DGod.SuparCar.Application.Settings;
using DGod.SuparCar.Infrastructure.DbContexts;
using DGod.SuparCar.Infrastructure.Identity.Models;
using DGod.SuparCar.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace DGod.SuparCar.Host.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddPersistenceContexts(configuration);
            // services.AddAuthenticationScheme(configuration);
        }

        private static void AddAuthenticationScheme(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(o =>
            {
                //Add Authentication to all Controllers by default.
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });
        }
        private static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("ConnectionStrings").Get<SqlSettings>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.ApplicationConnection));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }
        
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, SystemDateTimeService>();
        }
    }
}