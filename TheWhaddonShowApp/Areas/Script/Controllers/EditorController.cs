using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Script.Controllers
{
	[Area("Script")]
	[Route("Script/[controller]/[action]")]
	public class EditorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
