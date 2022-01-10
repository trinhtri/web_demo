using DGod.SuparCar.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DGod.SuparCar.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMenuService, MenuService>();
        }
    }
}

