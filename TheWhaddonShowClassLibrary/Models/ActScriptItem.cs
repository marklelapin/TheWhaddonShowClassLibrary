using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// Item in the script representing the start of a new Act
    /// </summary>
    public class ActScriptItem : ScriptItem
    {
        /// <summary>
        /// Title given to the Act.
        /// </summary>
        public string Title { get; set; } = "Currently No Title for Act (needs Correcting)";
    }
}
