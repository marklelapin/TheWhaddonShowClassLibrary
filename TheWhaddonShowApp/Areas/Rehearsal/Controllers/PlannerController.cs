using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Rehearsal.Controllers
{
	public class PlannerController : Controller
	{
		[Area("Rehearsal")]
		[Route("Rehearsal/[controller]/[action]")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
