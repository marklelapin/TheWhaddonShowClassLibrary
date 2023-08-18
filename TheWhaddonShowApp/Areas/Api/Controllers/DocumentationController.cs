using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowApp.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("Api/[controller]/[action]")]
    public class DocumentationController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
