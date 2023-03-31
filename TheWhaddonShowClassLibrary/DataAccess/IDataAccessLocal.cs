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

        public void deletePart(Part part);
        ///TODO once gone through Tim Corey text file data access



        //READ//

        /// <summary>
        /// Gets All Script Items from Local Storage
        /// </summary>
        /// <returns>All Script Items in Local Storage</returns>
        public List<ScriptItem> getScriptItems();

        /// <summary>
        /// Gets All Persons saved to Local Storage
        /// </summary>
        /// <returns>All Persons</returns>
        public List<Person> getPersons();

        /// <summary>
        /// Gets all Parts saved to local Storage
        /// </summary>
        /// <returns></returns>
        public List<Part> getParts();  

    }
}
