using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.DataAccess
{
    public interface IDataAccessLocal
    {
        //CREATE AND UPDATE//

        /// <summary>
        /// Stores all data re ScriptItems passed to it on Local Storage for processing in background when online. Creates a new record each time.
        /// </summary>
        /// <param name="scriptItem">ScriptItem to create or update</param>
        public void saveScriptItem(ScriptItem scriptItem);

        /// <summary>
        ///  Stores all data re Parts passed to it on Local Storage for processing in background when online.##
        ///  Overwrites existing record for specific Part if already on Local Storage.
        /// </summary>
        /// <param name="part"></param>
        public void savePart(Part part);

        /// <summary>
        ///  Stores all data re Persons passed to it on Local Storage for processing in background when online.Creates a new record each time.
        ///  Overwrites existing record for specific Person if already on Local Storage.
        /// </summary>
        /// <param name="part"></param>
        public void savePerson(Part part);


        //DELETE//

        //TODO - code to delete local storage files


        //READ//

        //TODO ADD Comments
        public List<ScriptItem> getScriptItems();

        //TODO ADD Comments
        public List<ScriptItem> getPersons(int personID, bool latestOnly = true);
        //TODO ADD comments
        public List<Part> getPartsByScriptItem(int? scriptItemID = null, bool activeOnly = true);  

    }
}
