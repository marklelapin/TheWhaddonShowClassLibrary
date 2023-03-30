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
    public class Person
    {
       /// <summary>
       /// The ID of the particular Whaddon Entertainer
       /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The First Name of the person.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// The Last Name of the Person
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// The email of the Person
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// A file path to the picture used within the app for the person.
        /// </summary>
        public string PictureRef { get; set; } = string.Empty;
        /// <summary>
        /// Identifies if the person is an actor. (available to be allocated to Parts)
        /// </summary>
        public  bool IsActor { get; set; }
        /// <summary>
        /// Identifies if the person is a singer. (available to be allocated to Singing Parts)
        /// </summary>
        public bool IsSinger { get; set; }
        /// <summary>
        /// Identifies if the person is a writer. (able to edit the Script)
        /// </summary>
        public bool IsWriter { get; set; }
        /// <summary>
        /// Identifies if the person is in the Band.
        /// </summary>
        public bool IsBand { get; set; }
        /// <summary>
        /// Identifies if the person is part of the technical team.
        /// </summary>
        public bool IsTechnical { get; set; }
        /// <summary>
        /// Identifies if the person is taking part in this years show and therefore active within the app.
        /// </summary>
        public bool IsActive { get; set; }

    }
}
