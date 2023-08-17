using Microsoft.AspNetCore.Mvc;

namespace AspStudio.Controllers;

public class RehearsalController : Controller
{
    public IActionResult Planner()
    {
        return View();
    }

    public IActionResult Calendar()
    {
        return View();
    }


}
