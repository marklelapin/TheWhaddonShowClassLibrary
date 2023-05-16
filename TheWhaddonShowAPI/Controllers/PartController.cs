using Microsoft.AspNetCore.Mvc;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Methods;
using System.Text.Json;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using TheWhaddonShowClassLibrary.Models;
using MyExtensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWhaddonShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IServerDataAccess _serverDataAccess;

        public PartController(IServerDataAccess serverDataAccess)
        {
            _serverDataAccess = serverDataAccess;
        }

        // GET: api/Part/
        [HttpGet( "{ids}")]
        public IActionResult Get([FromRoute] string ids)
        {
            List<Guid> guids = ids.ToListGuid();

            List<PartUpdate> partUpdates = _serverDataAccess.GetFromServer<PartUpdate>(guids);
            
            string output = JsonSerializer.Serialize(partUpdates);

            if (output == "[]") { return NotFound(); }
            
            return Ok(output);
        }

        // GET api/Part/changes/2023-05-09T10:23:56.024Z
        [HttpGet("changes/{lastSyncDate}")]
        public string GetChanges([FromRoute] DateTime lastSyncDate)
        {
            (List<PartUpdate> partUpdates, DateTime lastUpdatedOnServer) = _serverDataAccess.GetChangesFromServer<PartUpdate>(lastSyncDate);

            string output =  JsonSerializer.Serialize(partUpdates);

            return output;
        }

        // POST api/Part/
        [HttpPost("updates")]
        public DateTime Post([FromBody] List<PartUpdate> partUpdates)
        {
            DateTime result;

            result =  _serverDataAccess.SaveToServer(partUpdates);

            return result;
            
        }

        // POST api/Part/conflicts
        [HttpPost("conflicts")]
        public void PostConflicts([FromBody] List<Conflict> conflicts)
        {
         //   List<Conflict> partConflicts = JsonSerializer.Deserialize<List<Conflict>>(conflicts) ?? new List<Conflict>();

            _serverDataAccess.SaveConflictIdsToServer<PartUpdate>(conflicts);
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
