using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class MapController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
