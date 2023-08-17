using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheWhaddonShowApp.Models;

namespace TheWhaddonShowApp.Controllers;

public class TablesController : Controller
{
		public IActionResult TableElements()
		{
				return View();
		}

		public IActionResult TablePlugins()
		{
				return View();
		}
}