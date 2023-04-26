using MyClassLibrary.LocalServerMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// An update made to a part.
    /// </summary>
    public class PartUpdate : LocalServerIdentityUpdate
    {
        /// <summary>
        /// The name of the part.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The person playing the part
        /// </summary>
        public Guid PersonId { get;}

        /// <summary>
        /// List of additional Tags that can be associated with the Part
        /// </summary>
        public List<string>? Tags { get;}

        /// <summary>
        /// 
        /// </summary>
        public PartUpdate(Guid id, string name, List<string>? tags, Guid personID) : base(id)
        {
            Name = name;
            PersonId = personID;
            Tags = tags;
        }

        
        public List<Person> Person()
        {
            throw new NotImplementedException();
        }

    }
}
