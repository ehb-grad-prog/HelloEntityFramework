using HelloEntityFramework.Data;
using HelloEntityFramework.Entities;
using HelloEntityFramework.Localizers;
using HelloEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloEntityFramework.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseStringLocalizerFactory _factory;

    public UserRepository UserRepository { get; }
    public HelloEntityFrameworkContext Context { get; }

    public HomeController(ILogger<HomeController> logger, HelloEntityFrameworkContext context, DatabaseStringLocalizerFactory factory, IConfiguration configuration)
    {
        _logger = logger;
        Context = context;
        _factory = factory;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(CreateTranslationModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }

        Context.Translations.Add(new Translation
        {
            Key = model.Key,
            Value = model.Value,
            Language = model.Language
        });

        Context.SaveChanges();
        _factory.Update();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Update()
    {
        _factory.Update();

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
