using Microsoft.AspNetCore.Mvc;

namespace AspStudio.Controllers;

public class GalleryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
