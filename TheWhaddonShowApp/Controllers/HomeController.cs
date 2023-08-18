using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Home.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
