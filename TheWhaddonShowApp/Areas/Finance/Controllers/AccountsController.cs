using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Finance.Controllers
{
	[Area("Finance")]
	[Route("Finance/[controller]/[action]")]
	public class AccountsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
