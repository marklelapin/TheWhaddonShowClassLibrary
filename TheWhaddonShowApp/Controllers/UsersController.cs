using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class UsersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
