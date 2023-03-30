using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// A part within the show.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// The Identity for the Part
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The name of the part.
        /// </summary>
        public int Name { get; set; }
        
        /// <summary>
        /// The person playing the part
        /// </summary>
        public Person? Actor { get; set; }
        public  bool isSinging { get; set; }

    }
}
