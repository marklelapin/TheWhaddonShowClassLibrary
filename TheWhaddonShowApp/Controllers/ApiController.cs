﻿using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class ApiController : Controller
{
    public IActionResult Documentation()
    {
        return View();
    }

    public IActionResult Monitoring()
    {
        return View();
    }

    public IActionResult Testing()
    {
        return View();
    }

}
