using MyClassLibrary.LocalServerMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    public class Person : LocalServerIdentity<PersonUpdate>
    {
        public Person(LocalServerEngine<PersonUpdate> localServerEngine, Guid? id = null) : base(localServerEngine, id)
        {
        }
    }
}
