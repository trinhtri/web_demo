using System.Reflection;
using DGod.SuparCar.Application.Interfaces.Context;
using DGod.SuparCar.Application.Interfaces.Repositories;
using DGod.SuparCar.Infrastructure.DbContexts;
using DGod.SuparCar.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DGod.SuparCar.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        #region Repositories

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IPostRepository, PostRepository>();
        services.AddTransient<ILogRepository, LogRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        #endregion Repositories
    }
}