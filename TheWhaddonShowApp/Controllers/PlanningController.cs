using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class PlanningController : Controller
{
    public IActionResult Cast()
    {
        return View();
    }

    public IActionResult Props()
    {
        return View();
    }

    public IActionResult Costumes()
    {
        return View();
    }

}
