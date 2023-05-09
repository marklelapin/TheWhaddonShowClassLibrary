using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.LocalServerMethods;

namespace TheWhaddonShowClassLibrary.Models
{
    public class Part : LocalServerIdentity<PartUpdate>
    {
        public Part(LocalServerEngine<PartUpdate> localServerEngine, Guid? id = null) : base(localServerEngine, id)
        {
        }
    }
}
