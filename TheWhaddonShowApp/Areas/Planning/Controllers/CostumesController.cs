using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Planning.Controllers
{
	[Area("Planning")]
	[Route("Planning/[controller]/[action]")]
	public class CostumesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
