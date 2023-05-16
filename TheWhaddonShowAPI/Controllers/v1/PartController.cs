using Microsoft.AspNetCore.Mvc;
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;
using TheWhaddonShowClassLibrary.Models;
using MyExtensions;
using System.Web.Http.Filters;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWhaddonShowAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0",Deprecated = true)]
    public class PartController : ControllerBase
    {
        private readonly IServerDataAccess _serverDataAccess;
        private readonly IServerAPIControllerService<PartUpdate> _serverAPIControllerService;

        public PartController(IServerDataAccess serverDataAccess)
        {
            _serverDataAccess = serverDataAccess;
            _serverAPIControllerService = new ServerAPIControllerService<PartUpdate>(serverDataAccess);//TODO Think this should be done through dependency injection
        }

        // GET: api/Part/
        [HttpGet("{ids}")]
        public IActionResult Get([FromRoute] string ids)
        {
            string output = _serverAPIControllerService.Get(ids);

            if (output == "[]") { return NotFound(); }

            return Ok(output);
        }

        // GET api/Part/changes/2023-05-09T10:23:56.024Z
        [HttpGet("changes/{lastSyncDate}")]
        public IActionResult GetChanges([FromRoute] DateTime lastSyncDate)
        {
            string output = _serverAPIControllerService.GetChanges(lastSyncDate);

            if (output == "[]") { return NotFound(); }

            return Ok(output);
        }

        // POST api/Part/
        [HttpPost("updates")]
        [Authorize]
        public IActionResult Post([FromBody] List<PartUpdate> partUpdates)
        {
            DateTime output = _serverAPIControllerService.PostUpdates(partUpdates);

            if (output != DateTime.MinValue)
            {
                return Ok(output);
            }
            else
            {
                return NotFound();
            }

        }

        // POST api/Part/conflicts
        [HttpPost("conflicts")]
        [Authorize]
        public IActionResult PostConflicts([FromBody] List<Conflict> conflicts)
        {
            _serverAPIControllerService.PostConflicts(conflicts);

            return Ok();
        }

        ////// DELETE api/Part/
        ////[HttpDelete("{updates}")]
        ////public void Delete([FromBody] string updates)
        ////{

        ////    List<PartUpdate> partUpdates = JsonSerializer.Deserialize<List<PartUpdate>>(updates) ?? new List<PartUpdate>();

        ////    _serverDataAccess.DeleteFromServer(partUpdates);
        ////}
    }
}
