using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheWhaddonShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly ILogger<PublicController> _logger;

        public PublicController(ILogger<PublicController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { date = DateTime.UtcNow.ToString() });
        }
    }
}
