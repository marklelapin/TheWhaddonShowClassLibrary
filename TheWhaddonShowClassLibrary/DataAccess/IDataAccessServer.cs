using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.DataAccess
{
    public interface IDataAccessServer
    {

        //CREATE AND UPDATE//

        /// <summary>
        /// Creates or Updates Script History on Server depending on whether scriptItem.ID is null.
        /// Passing the new ID (if created) and UpdatedInHistory datetime back to ScriptItem.
        /// </summary>
        /// <param name="scriptItem">ScriptItem to create or update</param>
        public void saveScriptItem(ScriptItemUpdate scriptItem);
        
        /// <summary>
        /// Creates or Updates a Part on Server depending on whether Part.ID is null.
        /// Passes back new ID to same instance of Part (if created)
        /// </summary>
        /// <param name="part"></param>
        public void savePart(Part part);

        /// <summary>
        /// Creats or Updates a Person on Server depending on whether Person.ID is null.
        /// Passes back new ID to same instance of Person (if created)
        /// </summary>
        /// <param name="part"></param>
        public void savePerson(Part part);


        //DELETE//

        //Items Don't Get 'Deleted' - they get updated above with 'IsActive = false' 

       
        //READ//

        /// <summary>
        /// Gets ScriptItems from Server
        /// </summary>
        /// <param name="scriptItemID">If null(default) then returns all</param>
        /// <param name="latestOnly">if true(default) then returns only the latest Script Items for each ID. </param>
        /// <returns>ScriptItems below and including the given ScriptItemID</returns>
        public List<ScriptItemUpdate> getScriptItems(int? scriptItemID = null,bool latestOnly=true);

        /// <summary>
        /// Gets ScriptItems from Server
        /// </summary>
        /// <param name="personID">That relate to a given PersonID</param>
        /// <param name="latestOnly">if true(default) then returns only the latest Script Items for each ID. </param>
        /// <returns>All ScriptItems Relating to all Scenes involving PersonID</returns>
        public List<ScriptItemUpdate> getScriptItemsByPerson(int personID,bool latestOnly = true);

        /// <summary>
        /// Gets Parts from Server
        /// </summary>
        /// <param name="scriptItemID">If null(default) then returns all</param>
        /// <param name="activeOnly">Default to true. If false will return all parts inlcuding inactive ones.</param>
        /// <returns>All Parts relating to all scenes deriving from scriptItemID </returns>
        /// 
        public List<Part> getPartsByScriptItem(int? scriptItemID = null, bool activeOnly= true);
        /// <summary>
        /// Gets Parts from Server
        /// </summary>
        /// <param name="personID">That relate to a given PersonID</param>
        /// <param name="activeOnly">Default to true. If false will return all parts inactive parts as well.</param>
        /// <returns>All Parts relating the the given parameters</returns>
        public List<Part> getPartsByPerson(int personID,bool activeOnly = true);

        /// <summary>
        /// Gets Persons from Server
        /// </summary>
        /// <param name="scriptItemID">If null(default) then returns all</param>
        /// <param name="activeOnly">Default to true. If false will return all Persons inlcuding inactive ones.</param>
        /// <returns>All persons relating to the given parameters</returns>
        public List<PersonUpdate> getPersonsByScriptItem(int? scriptItemID = null, bool activeOnly = true);


    }
}
