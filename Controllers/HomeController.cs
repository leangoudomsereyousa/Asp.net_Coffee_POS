using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Coffee_POS.Models;

namespace Coffee_POS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();

    }
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Review()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Menu()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddContact(UserContact model)
    {
        if (!ModelState.IsValid)
            return View("Contact");

        // Save to DB here
        return RedirectToAction("Contact");
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
