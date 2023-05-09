using Microsoft.AspNetCore.Mvc;
using MyClassLibrary.LocalServerMethods;
using Newtonsoft.Json;
using TheWhaddonShowClassLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWhaddonShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IServerDataAccess _serverDataAccess;

        public PartsController (IServerDataAccess serverDataAccess)
        {
            _serverDataAccess = serverDataAccess;
        }

        // GET: api/parts/
        [HttpGet("{ids}")]
        public string Get(string ids)
        {
            List<Guid> idsList = new List<Guid>();
            idsList = JsonConvert.DeserializeObject<List<Guid>>(ids) ?? new List<Guid>();

            List<PartUpdate> partUpdates = _serverDataAccess.GetFromServer<PartUpdate>(idsList);
            
            string output = JsonConvert.SerializeObject(partUpdates);

            return output;
        }

        // GET api/parts/changes/2023-05-09T10:23:56.024Z
        [HttpGet("changes/{lastSyncDate}")]
        public string GetChanges(DateTime lastSyncDate)
        {
            (List<PartUpdate> partUpdates, DateTime lastUpdatedOnServer) = _serverDataAccess.GetChangesFromServer<PartUpdate>(lastSyncDate);

            string output =  JsonConvert.SerializeObject(partUpdates);

            return output;
        }

        // POST api/parts/
        [HttpPost("{updates}")]
        public void Post([FromBody] string updates)
        { 
            List<PartUpdate> partUpdates = JsonConvert.DeserializeObject<List<PartUpdate>>(updates) ?? new List<PartUpdate>();

            _serverDataAccess.SaveToServer(partUpdates);
        }

        // POST api/parts/conflicts
        [HttpPost("conflicts/{conflicts}")]
        public void PostConflicts([FromBody] string conflicts)
        {
            List<Conflict> partConflicts = JsonConvert.DeserializeObject<List<Conflict>>(conflicts) ?? new List<Conflict>();

            _serverDataAccess.SaveConflictIdsToServer<PartUpdate>(partConflicts);
        }

        // DELETE api/parts/
        [HttpDelete("{updates}")]
        public void Delete([FromBody] string updates)
        {

            List<PartUpdate> partUpdates = JsonConvert.DeserializeObject<List<PartUpdate>>(updates) ?? new List<PartUpdate>();

            _serverDataAccess.DeleteFromServer(partUpdates);
        }
    }
}
