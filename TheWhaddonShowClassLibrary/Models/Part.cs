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
    public class Part
    {
        LocalServerIdentity _localServerIdentity = new LocalServerIdentity();
        
        public Guid Id { get; private set; }
        public PartUpdate LatestUpdate { get; private set; }
        
        public List<PartUpdate> PartHistory()
        {
            return _localServerIdentity.GetHistory<PartUpdate>(Id);
        }
    
        public Part (Guid id)
        {
            Id = id;
            LatestUpdate = _localServerIdentity.GetLatestUpdate<PartUpdate>(new List<Guid>() { id })[0];
            
        }

    }
}
