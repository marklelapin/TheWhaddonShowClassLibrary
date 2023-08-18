using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Users.Controllers
{
	[Area("Users")]
	[Route("Users/[controller]/[action]")]
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
