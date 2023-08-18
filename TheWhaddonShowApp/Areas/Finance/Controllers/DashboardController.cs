using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Finance.Controllers
{
	[Area("Finance")]
	[Route("Finance/[controller]/[action]")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
