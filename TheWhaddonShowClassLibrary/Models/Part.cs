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
    /// A part within the show.
    /// </summary>
    public class Part : LocalServerIdentity
    {
        /// <summary>
        /// The name of the part.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The person playing the part
        /// </summary>
        public Person? Actor { get; set; }

        /// <summary>
        /// List of additional Tags that can be associated with the Part
        /// </summary>
        public List<string> Tags { get; set; }


        public Part(string name)
        {
            Name = name;
            Actor = null;
            Tags = new List<string>();
            try
            {
                //run save (without null ID) functoin save to Server data withoutID and get a return ID back. JOb Done
                
            }
            catch (Exception)
            {
                //create localtempID if null 
                //save to Local

                throw;
            }

            //either way it comes back with an ID
            
        }


        //periodically see if stuff exists in save fodle if it does - try the above again. If local ID is present then keep that.




    }
}
