using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class ShowController : Controller
{
    public IActionResult Website()
    {
        return View();
    }

    public IActionResult Tickets()
    {
        return View();
    }

    public IActionResult Programme()
    {
        return View();
    }

}
