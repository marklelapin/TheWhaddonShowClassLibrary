using Microsoft.AspNetCore.Mvc;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Methods;
using System.Text.Json;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using TheWhaddonShowClassLibrary.Models;
using MyExtensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWhaddonShowAPI.Controllers.v2
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class PersonController : ControllerBase
    {
        private readonly IServerDataAccess _serverDataAccess;

        public PersonController(IServerDataAccess serverDataAccess)
        {
            _serverDataAccess = serverDataAccess;
        }

        // GET: api/Person/
        [HttpGet("{ids}")]
        public IActionResult Get([FromRoute] string ids)
        {
            List<Guid> guids = ids.ToListGuid();

            List<PersonUpdate> personUpdates = _serverDataAccess.GetFromServer<PersonUpdate>(guids);

            string output = JsonSerializer.Serialize(personUpdates);

            if (output == "[]") { return NotFound(); }

            return Ok(output);
        }

        // GET api/Person/changes/2023-05-09T10:23:56.024Z
        [HttpGet("changes/{lastSyncDate}")]
        public string GetChanges([FromRoute] DateTime lastSyncDate)
        {
            (List<PersonUpdate> updates, DateTime lastUpdatedOnServer) = _serverDataAccess.GetChangesFromServer<PersonUpdate>(lastSyncDate);

            string output = JsonSerializer.Serialize(updates);

            return output;
        }

        // POST api/Person/
        [HttpPost("updates")]
        public DateTime Post([FromBody] List<PersonUpdate> personUpdates)
        {
            DateTime result;

            result = _serverDataAccess.SaveToServer(personUpdates);

            return result;

        }

        // POST api/Person/conflicts
        [HttpPost("conflicts")]
        public void PostConflicts([FromBody] List<Conflict> conflicts)
        {
            //   List<Conflict> personConflicts = JsonSerializer.Deserialize<List<Conflict>>(conflicts) ?? new List<Conflict>();

            _serverDataAccess.SaveConflictIdsToServer<PersonUpdate>(conflicts);
        }

        ////// DELETE api/Person/
        ////[HttpDelete("{updates}")]
        ////public void Delete([FromBody] string updates)
        ////{

        ////    List<PersonUpdate> personUpdates = JsonSerializer.Deserialize<List<PersonUpdate>>(updates) ?? new List<PersonUpdate>();

        ////    _serverDataAccess.DeleteFromServer(personUpdates);
        ////}
    }
}
