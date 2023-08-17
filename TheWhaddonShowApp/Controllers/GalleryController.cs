using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class GalleryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
