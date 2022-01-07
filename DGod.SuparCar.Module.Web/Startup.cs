using StartupBase = OrchardCore.Modules.StartupBase;

namespace  DGod.SuparCar.Modules.Web.Controllers
{
    public class Startup : StartupBase
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute
            (
                name: "Home",
                areaName: "DGod.SuparCar.Module.Web",
                pattern: "",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
