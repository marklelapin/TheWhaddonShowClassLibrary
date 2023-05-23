using Microsoft.AspNetCore.Mvc;
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;
using TheWhaddonShowClassLibrary.Models;
using MyExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWhaddonShowAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ScriptItemController : ControllerBase
    {
        private readonly IServerDataAccess _serverDataAccess;
        private readonly IServerAPIControllerService<ScriptItemUpdate> _serverAPIControllerService;

        public ScriptItemController(IServerDataAccess serverDataAccess,ILogger<ScriptItemUpdate> logger)
        {
            _serverDataAccess = serverDataAccess;
            _serverAPIControllerService = new ServerAPIControllerService<ScriptItemUpdate>(serverDataAccess,logger);//TODO Think this should be done through dependency injection
        }

        // GET: api/ScriptItem/0F93A0CF-F96E-4045-8CEB-12EDCAA3A15F,4384C339-F749-47A0-B684-C48C67F3C5D0
        /// <summary>
        /// Gets all of the updates made to a ScriptItem(s) passed in.
        /// </summary>
        /// <remarks>
        /// This gives a history of all updates made to the ScriptItem(s).
        /// 
        /// The update with the latest created date is the most current.
        /// 
        /// To get data a guid or a comma separated list of guids needs to be passed in as a QUERY as shown below:
        /// 
        /// 'apt/v2/ScriptItem/?ids=0DE2C9A4-41F7-4170-9BDF-04B7B8F64197,744BD79A-1A2B-425F-874F-315A3B3BA9F2,FC97305D-8A92-42D5-94DB-6FC9F5FF1432,ED789FA3-4B2B-41A0-A322-773ED7CE89FE,ED789FA3-4B2B-41A0-A322-773ED7CE89FE,CD42AD02-CC02-4AA4-8AB6-8C4ACB2E9858,79E604CF-7CC2-41F6-B37F-F30C76AB5F34,10DD3D80-5853-424B-999D-FB758565B03E'
        /// 
        /// The API will respond with a 404 Not Found error if no scriptItems relate to the Ids given.
        /// 
        /// Otherwise it will return a json string of ScriptItemUpdates.
        /// 
        /// </remarks>
        [HttpGet]
        public IActionResult Get([FromQuery] string ids)
        {
            (HttpStatusCode statusCode, string result) = _serverAPIControllerService.Get(ids);

            return new ObjectResult(result) { StatusCode = (int)statusCode };
        }

        // GET api/ScriptItem/changes/2023-05-09T10:23:56.024Z
        /// <summary>
        /// Gets all the updates made to any ScriptItem since the lastSyncDate passed in.
        /// </summary>
        /// <remarks>
        /// To get data a date in the format 'yyyy-MM-ddThh:mm:ss.ffffff' needs to be passed as indicated below
        /// 
        /// 'api/v2/ScriptItem/2023-05-09T10:23:56.024
        /// 
        /// The API will respond with a 404 Not Found error if no changes have been made since this Date and Time.
        /// 
        /// Otherwise it will return a json string of ScriptItemUpdates.
        /// </remarks>

        [HttpGet("changes/{lastSyncDate}")]
        public IActionResult GetChanges([FromRoute] DateTime lastSyncDate)
        {
            (HttpStatusCode statusCode, string result) = _serverAPIControllerService.GetChanges(lastSyncDate);

            return new ObjectResult(result) { StatusCode = (int)statusCode };
        }

        // POST api/ScriptItem/
        /// <summary>
        /// Creates or Updates a ScriptItem(s) by posting a ScriptItemUpdate. (AUTHORISATON Through Azure AdB2C required)
        /// </summary>
        /// <remarks>   
        /// 
        /// Authorisation is required to write to the central database. Use Contact above to obtain relevant ClientIds etc.
        /// 
        /// This method is how you create or update a ScriptItem since in both cases this is done by adding an adddtional ScriptItemUpdate that supercedes the current update in the system.
        /// If a new Script Item is being created a new GUID for Id needs to be created.
        /// 
        /// Json Text containing all properties of the update to be made must be passed in the body of the text as shown below:
        /// 
        /// [
        /// 
        ///     {
        ///     
        ///     "ParentId":"4b617887-849d-406b-bdbb-43e1ddca5d39"
        ///     
        ///     ,"OrderNo":1
        ///     
        ///     ,"Type":"Dialogue"
        ///     
        ///     ,"Text":"He said something"
        ///     
        ///     ,"PartIds":["c0e28400-8bcd-4761-a7c1-5e241b44ff9a"]
        ///     
        ///     ,"Tags":null
        ///     
        ///     ,"Id":"0d214c35-dba2-46bd-a71f-4549352136d3"
        ///     
        ///     ,"ConflictId":null
        ///     
        ///     ,"Created":"2023-05-17T12:17:12"
        ///     
        ///     ,"UpdatedOnServer":null
        ///     
        ///     ,"CreatedBy":"mcarter"
        ///     
        ///     ,"IsActive":true
        ///     
        ///     }  
        ///     
        /// ]
        /// 
        /// The API will return the date and time the Server was Updated if successful.  In the format 'yyyy-MM-ddThh:mm:ss.fffffff' 
        /// 
        /// </remarks>
        [HttpPost("updates")]
        [Authorize]
        [RequiredScope("show.write")]
        public IActionResult Post([FromBody] List<ScriptItemUpdate> updates)
        {
            (HttpStatusCode statusCode, string result) = _serverAPIControllerService.PostUpdates(updates);

            return new ObjectResult(result) { StatusCode = (int)statusCode };

        }

        // POST api/ScriptItem/conflicts
        /// <summary>
        /// Posts a ConflictId to a specific Id and Created date of a ScriptItem.  (AUTHORISATON Through Azure AdB2C required)
        /// </summary>
        /// <remarks>   
        /// 
        /// Authorisation is required to write to the central database. Use Contact above to obtain relevant ClientIds etc.
        /// 
        /// Conflicts identify ScriptItems where updates exist from different sources and need to be resolved.
        /// 
        /// This adds a ConflictId to a specific ScriptItemUpdate where UpdateID and UpdateCreated match an existing Id and Created date on the central database
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
        [Authorize]
        [RequiredScope("show.write")]
        public IActionResult PostConflicts([FromBody] List<Conflict> conflicts)
        {
            (HttpStatusCode statusCode, string result) = _serverAPIControllerService.PostConflicts(conflicts);

            return new ObjectResult(result) { StatusCode = (int)statusCode };
        }

        ////// DELETE api/ScriptItem/
        ////[HttpDelete("{updates}")]
        ////public void Delete([FromBody] string updates)
        ////{

        ////    List<ScriptItemUpdate> scriptItemUpdates = JsonSerializer.Deserialize<List<ScriptItemUpdate>>(updates) ?? new List<ScriptItemUpdate>();

        ////    _serverDataAccess.DeleteFromServer(scriptItemUpdates);
        ////}
    }
}
