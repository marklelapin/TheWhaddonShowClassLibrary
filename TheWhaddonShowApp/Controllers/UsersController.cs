using Microsoft.AspNetCore.Mvc;

namespace AspStudio.Controllers;

public class UsersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
