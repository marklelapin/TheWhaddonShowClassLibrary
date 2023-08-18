using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Settings.Controllers
{
	[Area("Settings")]
	[Route("Settings/[controller]/[action]")]
	public class SettingsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
