using HelloEntityFramework.Data;
using HelloEntityFramework.Entities;
using HelloEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HelloEntityFramework.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HelloEntityFrameworkContext _context;

    public HomeController(ILogger<HomeController> logger, HelloEntityFrameworkContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var users = _context.Users
            .ToList();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
