﻿using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Controllers;

public class EmailController : Controller
{
    public IActionResult Inbox()
    {
        return View();
    }

    public IActionResult Compose()
    {
        return View();
    }

    public IActionResult Detail()
    {
        return View();
    }
}