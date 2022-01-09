﻿using DGod.SuparCar.Application.Extensions;
using DGod.SuparCar.Host.Extensions;
using DGod.SuparCar.Host.Permission;
using DGod.SuparCar.Infrastructure.CacheRepository.Extensions;
using DGod.SuparCar.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace DGod.SuparCar.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add ASP.NET MVC and support for modules
            services.AddSingleton<IAuthorizationPolicyProvider,PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddOptions();
            services.AddDistributedMemoryCache();
            services.AddApplicationLayer();
            services.AddInfrastructure(_configuration);
            services.AddPersistenceContexts(_configuration);
            services.AddSharedInfrastructure(_configuration);
            services.AddRepositories();
            services.AddCacheRepositories();
            services
                .AddOrchardCore()
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseOrchardCore();
        }
    }
}

