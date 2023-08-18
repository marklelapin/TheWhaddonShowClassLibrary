

using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Planning.Controllers
{
	[Area("Planning")]
	[Route("Planning/[controller]/[action]")]
	public class CastController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
