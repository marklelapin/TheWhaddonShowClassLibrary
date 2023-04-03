using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.DataAccess
{
    public class SQLConnector : IDataAccessServer
    {
        private static string CnnString = "connection string to be sort out";

        public List<Part> getPartsByPerson(int personID, bool activeOnly = true)
        {
            throw new NotImplementedException();
        }

        public List<Part> getPartsByScriptItem(int? scriptItemID = null, bool activeOnly = true)
        {
            throw new NotImplementedException();
        }

        public List<PersonUpdate> getPersonsByScriptItem(int? scriptItemID = null, bool activeOnly = true)
        {
            throw new NotImplementedException();
        }

        public List<ScriptItemUpdate> getScriptItems(int? scriptItemID = null, bool latestOnly = true)
        {
            throw new NotImplementedException();
        }

        public List<ScriptItemUpdate> getScriptItemsByPerson(int personID, bool latestOnly = true)
        {
            throw new NotImplementedException();
        }

        public void savePart(Part part)
        {
            throw new NotImplementedException();
        }

        public void savePerson(Part part)
        {
            throw new NotImplementedException();
        }

        public void saveScriptItem(ScriptItemUpdate scriptItem)
        {
            throw new NotImplementedException();
        }
    }
}
