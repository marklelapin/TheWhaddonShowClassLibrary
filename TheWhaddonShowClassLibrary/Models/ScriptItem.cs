using MyClassLibrary.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    public class ScriptItem
    {
        LocalServerIdentity _localServerIdentity = new LocalServerIdentity();   
        public Guid Id { get; set; }

        public ScriptItemUpdate LatestUpdate { get; set; }

        public List<ScriptItemUpdate> History() {
            return _localServerIdentity.GetHistory<ScriptItemUpdate>(Id);
        }

        public ScriptItem(Guid id)
        {
            Id = id;
            LatestUpdate = _localServerIdentity.GetLatestUpdate<ScriptItemUpdate>(new List<Guid> { id })[0];
            
        }


    }
}
