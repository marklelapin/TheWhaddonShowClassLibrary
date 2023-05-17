using Microsoft.AspNetCore.Mvc;
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;
using TheWhaddonShowClassLibrary.Models;
using MyExtensions;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWhaddonShowAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class PartController : ControllerBase
    {
        private readonly IServerDataAccess _serverDataAccess;
        private readonly IServerAPIControllerService<PartUpdate> _serverAPIControllerService;

        public PartController(IServerDataAccess serverDataAccess)
        {
            _serverDataAccess = serverDataAccess;
            _serverAPIControllerService = new ServerAPIControllerService<PartUpdate>(serverDataAccess);//TODO Think this should be done through dependency injection
        }

        // GET: api/Part/0F93A0CF-F96E-4045-8CEB-12EDCAA3A15F,4384C339-F749-47A0-B684-C48C67F3C5D0
        /// <summary>
        /// Gets all of the updates made to a Part(s) passed in.
        /// </summary>
        /// <remarks>
        /// This gives a history of all updates made to the Part(s).
        /// 
        /// The update with the latest created date is the most current.
        /// 
        /// To get data a guid or a comma separated list of guids needs to be passed in as a path parameter as shown below:
        /// 
        /// 'apt/v2/Part/0F93A0CF-F96E-4045-8CEB-12EDCAA3A15F,4384C339-F749-47A0-B684-C48C67F3C5D0'
        /// 
        /// The API will respond with a 404 Not Found error if no parts relate to the Ids given.
        /// 
        /// Otherwise it will return a json string of PartUpdates.
        /// 
        /// </remarks>
        [HttpGet("{ids}")]
        public IActionResult Get([FromRoute] string ids)
        {
            string output = _serverAPIControllerService.Get(ids);

            if (output == "[]") { return NotFound(); }

            return Ok(output);
        }

        // GET api/Part/changes/2023-05-09T10:23:56.024Z
        /// <summary>
        /// Gets all the updates made to any Part since the lastSyncDate passed in.
        /// </summary>
        /// <remarks>
        /// To get data a date in the format 'yyyy-MM-ddThh:mm:ss.ffffff' needs to be passed as indicated below
        /// 
        /// 'api/v2/Part/2023-05-09T10:23:56.024
        /// 
        /// The API will respond with a 404 Not Found error if no changes have been made since this Date and Time.
        /// 
        /// Otherwise it will return a json string of PartUpdates.
        /// </remarks>
        
        [HttpGet("changes/{lastSyncDate}")]
        public IActionResult GetChanges([FromRoute] DateTime lastSyncDate)
        {
            string output = _serverAPIControllerService.GetChanges(lastSyncDate);

            if (output == "[]") { return NotFound(); }

            return Ok(output);
        }

        // POST api/Part/
        /// <summary>
        /// Creates or Updates a Part(s) by posting a PartUpdate.
        /// </summary>
        /// <remarks>   
        /// This method is how you create or update a Part since in both cases this is done by adding an adddtional PartUpdate that supercedes the current update in the system.
        /// If a new Part is being created a new Guid needs to be created for Id.
        /// Json Text containing all properties of the update to be made must be passed in the body of the text as shown below:
        /// 
        /// 
        /// [
        /// 
        ///         {   "Name":"Rodney",
        ///         
        ///             "Id":"08a0b93a-ee8f-4d4a-a120-d9ee6a2817dc",
        ///             
        ///             "PersonId":"b7b59aa8-34f7-4d2c-ac97-68a6efd4a3c9",
        ///             
        ///             "Tags":["Trotter","Side"],
        ///             
        ///             "ConflictId":null,
        ///             
        ///             "Created":"2023-05-15T12:16:10",
        ///             
        ///             "UpdatedOnServer":"",
        ///             
        ///             "CreatedBy":"mcarter",
        ///             
        ///             "IsActive":false
        ///             
        ///             },
        ///             
        ///          { "Name":"Uncle Albert",
        ///          
        ///             "PersonId":"bb2f3007-9c4c-4f41-a360-d1ea59f26f04",
        ///             
        ///             "Tags":[],
        ///             
        ///             "Id":"0b64f14f-3725-41e1-b981-778acab1ad8c",
        ///             
        ///             "ConflictId":null,
        ///             
        ///             "Created":"2023-05-15T12:16:11",
        ///             
        ///             "UpdatedOnServer":"",
        ///             
        ///             "CreatedBy":"mcarter",
        ///             
        ///             "IsActive":true
        ///             
        ///             } 
        ///             
        /// ]
        /// 
        /// The API will return the date and time the Server was Updated if successful.  In the format 'yyyy-MM-ddThh:mm:ss.fffffff'
        /// 
        /// 
        /// </remarks>
        /// <param name="partUpdates"></param>
        /// <returns></returns>
        [HttpPost("updates")]
       // [Authorize]
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
        /// <summary>
        /// Posts a ConflictId to a specific Id and Created date of a Part.
        /// </summary>
        /// <remarks>   
        /// Conflicts identify Parts where updates exist from different sources and need to be resolved.
        /// 
        /// This adds a ConflictId to a specific PartUpdate where UpdateID and UpdateCreated match an existing Id and Created date on the central database
        /// 
        /// Json Text containing all properties of the update to be made must be passed in the body of the text as shown below:
        /// 
        /// [
        ///     {
        ///     
        ///         "conflictId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         
        ///         "updateId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         
        ///         "updateCreated": "2023-05-17T06:54:23.465Z"
        ///         
        ///     }
        /// ]
        /// 
        /// </remarks>
        /// <param name="conflicts"></param>
        /// <returns></returns>
        [HttpPost("conflicts")]
        //[Authorize]
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
