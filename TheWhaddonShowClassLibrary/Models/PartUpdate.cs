
using MyClassLibrary.LocalServerMethods.Models;
using System.Text.Json.Serialization;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// An update made to a part.
    /// </summary>
    public class PartUpdate : LocalServerModelUpdate
    {
        /// <summary>
        /// The name of the part.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// The person playing the part
        /// </summary>
        public Guid? PersonId { get;}

        /// <summary>
        /// List of additional Tags that can be associated with the Part
        /// </summary>
        public List<string>? Tags { get;}



        public PartUpdate ()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public PartUpdate(Guid id, string name, List<string>? tags, Guid personID) : base(id)
        {
            Name = name;
            PersonId = personID;
            Tags = tags;
        }

        
        [JsonConstructor]
        public PartUpdate(Guid id, DateTime created, string createdBy, DateTime? updatedOnServer, bool isConflicted, bool isActive, bool isSample, string name, Guid? personID,List<string>? tags) : base(id)
        {
            Id = id;
            Created = created;
            CreatedBy = createdBy;
            UpdatedOnServer = updatedOnServer;
            IsConflicted = isConflicted;
            IsActive = isActive;
            IsSample = isSample;
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
