using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheWhaddonShowApp.Models;

namespace TheWhaddonShowApp.Controllers;

public class WidgetsController : Controller
{
		public IActionResult Index()
		{
				return View();
		}
}
