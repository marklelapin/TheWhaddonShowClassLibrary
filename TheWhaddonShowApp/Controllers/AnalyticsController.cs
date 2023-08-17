using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class AnalyticsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
