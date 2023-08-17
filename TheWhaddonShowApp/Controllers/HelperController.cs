using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class HelperController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}