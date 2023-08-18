using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Show.Controllers
{
	[Area(areaName: "Show")]
	[Route("Show/[controller]/[action]")]
	public class TicketsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
