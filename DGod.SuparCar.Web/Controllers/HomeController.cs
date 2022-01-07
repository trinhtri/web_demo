using System.Diagnostics;
using DGod.SuparCar.Application.Interfaces.Repositories;
using DGod.SuparCar.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using DGod.SuparCar.Web.Models;
using MediatR;

namespace DGod.SuparCar.Web.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
