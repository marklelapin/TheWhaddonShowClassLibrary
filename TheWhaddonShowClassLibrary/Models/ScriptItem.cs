using MyClassLibrary.LocalServerMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    public class ScriptItem : LocalServerIdentity<ScriptItemUpdate>
    {
        public ScriptItem(ILocalServerEngine<ScriptItemUpdate> localServerEngine, Guid? id = null) : base(localServerEngine, id)
        {
        }
    }
}
