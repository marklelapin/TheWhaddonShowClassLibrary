using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class CalendarController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
