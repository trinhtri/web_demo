using System.Reflection;
using DGod.SuparCar.Application.Interfaces.CacheRepositories;
using DGod.SuparCar.Application.Interfaces.Context;
using DGod.SuparCar.Application.Interfaces.Repositories;
using DGod.SuparCar.Infrastructure.CacheRepository.CacheRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DGod.SuparCar.Infrastructure.CacheRepository.Extensions;

public static class ServiceCollectionExtensions
{

    public static void AddCacheRepositories(this IServiceCollection services)
    {
        #region Repositories
        
        services.AddTransient<IPostCacheRepository, PostCacheRepository>();

        #endregion Repositories
    }
}