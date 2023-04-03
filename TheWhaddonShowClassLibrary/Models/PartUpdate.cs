using MyClassLibrary.Methods;
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
    public class PartUpdate : LocalServerIdentity
    {
        /// <summary>
        /// The name of the part.
        /// </summary>
        protected string Name { get; set; }
        
        /// <summary>
        /// The person playing the part
        /// </summary>
        protected PersonUpdate? Actor { get;}

        /// <summary>
        /// List of additional Tags that can be associated with the Part
        /// </summary>
        protected List<string>? Tags { get;}

        public PartUpdate(string name, List<string>? tags = null, PersonUpdate? actor = null) : base()
        {
            Name = name;
            Actor = actor;
            Tags = tags;
        }
        
        public PartUpdate(Guid id, string name, List<string>? tags, PersonUpdate? actor) : base(id)
        {
            Name = name;
            Actor = actor;
            Tags = tags;
        }

        public PartUpdate(PartUpdate partUpdate,bool isActive) : base(partUpdate.Id,isActive)
        {
                Name = partUpdate.Name;
                Actor = partUpdate.Actor;
                Tags = partUpdate.Tags;
        }



    }
}
