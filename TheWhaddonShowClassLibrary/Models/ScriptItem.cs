using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;

namespace TheWhaddonShowClassLibrary.Models
{
    public class ScriptItem : LocalServerModel<ScriptItemUpdate>, ILocalServerModel<ScriptItemUpdate>
    {
        public ScriptItem() : base()
        {

        }
    }
}
