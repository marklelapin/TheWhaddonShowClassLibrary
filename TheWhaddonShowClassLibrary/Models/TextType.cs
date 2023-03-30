using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// The text type of the script item. ie whether it is dialogue or action etc.
    /// </summary>
    public class TextType
    {   
        /// <summary>
        /// The identity of the Text Type
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The name of the Text Type
        /// </summary>
        public string Title { get; set; } = string.Empty;
    }
}
