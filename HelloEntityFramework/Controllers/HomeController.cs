using HelloEntityFramework.Data;
using HelloEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloEntityFramework.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public UserRepository UserRepository { get; }

    public HomeController(ILogger<HomeController> logger, UserRepository userRepository)
    {
        _logger = logger;
        UserRepository = userRepository;
    }

    public IActionResult Index()
    {
        var user = UserRepository.FindById(1);

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
