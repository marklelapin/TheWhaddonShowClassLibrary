using MyClassLibrary.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// A person taking part in the show. (or previous participant if inActive)
    /// </summary>
    public class PersonUpdate : LocalServerIdentity
    {
        /// <summary>
        /// The First Name of the person.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// The Last Name of the Person
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// The email of the Person
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// A file path to the picture used within the app for the person.
        /// </summary>
        public string? PictureRef { get; set; }
        /// <summary>
        /// Identifies if the person is an actor. (available to be allocated to Parts)
        /// </summary>
        public  bool IsActor { get; set; } = false;
        /// <summary>
        /// Identifies if the person is a singer. (available to be allocated to Singing Parts)
        /// </summary>
        public bool IsSinger { get; set; } = false;
        /// <summary>
        /// Identifies if the person is a writer. (able to edit the Script)
        /// </summary>
        public bool IsWriter { get; set; } = false;
        /// <summary>
        /// Identifies if the person is in the Band.
        /// </summary>
        public bool IsBand { get; set; } = false;
        /// <summary>
        /// Identifies if the person is part of the technical team.
        /// </summary>
        public bool IsTechnical { get; set; } = false;

        public PersonUpdate(string firstName,string? lastName = null,string? email = null,string? pictureRef = null,bool? isActor = null,
            bool? isSinger = null,bool? isWriter = null, bool? isBand = null, bool? isTechnical = null) : base ()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PictureRef = pictureRef;
            IsActor = isActor ?? false;
            IsSinger = isSinger ?? false;
            IsWriter = isWriter ?? false;
            IsBand = isBand ?? false;
            IsTechnical = isTechnical ?? false;
        }

        public PersonUpdate(Guid id, string firstName, string? lastName = null, string? email = null, string? pictureRef = null, bool? isActor = null,
           bool? isSinger = null, bool? isWriter = null, bool? isBand = null, bool? isTechnical = null) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PictureRef = pictureRef;
            IsActor = isActor ?? false;
            IsSinger = isSinger ?? false;
            IsWriter = isWriter ?? false;
            IsBand = isBand ?? false;
            IsTechnical = isTechnical ?? false;
        }

        public PersonUpdate(PersonUpdate personUpdate,bool isActive) : base(personUpdate.Id,isActive)
        {
            FirstName = personUpdate.FirstName;
            LastName = personUpdate.LastName;
            Email = personUpdate.Email;
            PictureRef = personUpdate.PictureRef;
            IsActor = personUpdate.IsActor;
            IsSinger= personUpdate.IsSinger;
            IsWriter = personUpdate.IsWriter;
            IsBand = personUpdate.IsBand;
            IsTechnical = personUpdate.IsTechnical;
        }


 
    }
}
