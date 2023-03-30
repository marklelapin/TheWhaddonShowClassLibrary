using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// Represents the start of a new set of lines for a Part within the scene.
    /// </summary>
    public class LineScriptItem
    {
        /// <summary>
        /// The Part the lines relate to.
        /// </summary>
        Part? Part { get; set; }
    }
}
