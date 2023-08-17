using Microsoft.AspNetCore.Mvc;

namespace AspStudio.Controllers;

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
