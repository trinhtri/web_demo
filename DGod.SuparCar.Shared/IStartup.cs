using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DGod.SuparCar.Shared
{
    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}   