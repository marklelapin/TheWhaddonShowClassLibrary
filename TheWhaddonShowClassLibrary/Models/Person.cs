using MyClassLibrary.LocalServerMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    internal class Person
    {
        LocalServerIdentity _localServerIdentity = new LocalServerIdentity();

        public Guid Id { get; set; }
        public PersonUpdate LatestUpdate { get; set; }

        public List<PersonUpdate> GetHistory()
        {
            return _localServerIdentity.GetHistory<PersonUpdate>(Id);

        }
        public Person(Guid id)
        {
            Id = id;
            LatestUpdate = _localServerIdentity.GetLatestUpdate<PersonUpdate>(new List<Guid>() { id })[0];
        }

    }
}
