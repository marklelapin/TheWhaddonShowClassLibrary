using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class FormsController : Controller
{
    public IActionResult FormElements()
    {
        return View();
    }

    public IActionResult FormPlugins()
    {
        return View();
    }

    public IActionResult Wizards()
    {
        return View();
    }
}