using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Gallery.Controllers
{
	[Area("Gallery")]
	[Route("Gallery/[controller]/[action]")]
	public class GalleryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
