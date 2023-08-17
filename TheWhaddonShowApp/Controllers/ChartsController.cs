using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class ChartsController : Controller
{
    public IActionResult ChartJs()
    {
        return View();
    }

    public IActionResult ApexchartsJs()
    {
        return View();
    }
}
