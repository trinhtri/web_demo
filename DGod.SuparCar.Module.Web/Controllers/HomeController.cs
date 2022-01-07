using Microsoft.AspNetCore.Mvc;

namespace DGod.SuparCar.Modules.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
