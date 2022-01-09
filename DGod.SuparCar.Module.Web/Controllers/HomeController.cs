using DGod.SuparCar.Application.Constants;
using DGod.SuparCar.Application.Enums;
using DGod.SuparCar.Application.Interfaces.CacheRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DGod.SuparCar.Modules.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
