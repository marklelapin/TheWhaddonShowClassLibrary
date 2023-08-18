using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Rehearsal.Controllers
{
	[Area("Rehearsal")]
	[Route("Rehearsal/[controller]/[action]")]
	public class CalendarController : Controller
	{
		public IActionResult Index()
		{

			return View();
		}
	}
}
