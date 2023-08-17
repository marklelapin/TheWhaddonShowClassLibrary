using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class FinanceController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Accounts()
    {
        return View();
    }


}
