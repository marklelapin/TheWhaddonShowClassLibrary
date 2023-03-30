using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// An Item at the top of the Script Heirachy representing the start of the show.
    /// </summary>
    public class ShowScriptItem : ScriptItem
    {
        /// <summary>
        /// The Title of the specific Whaddon Show
        /// </summary>
        public string Title { get; set; } = "Currently No Title for Show (needs Correcting)";

        /// <summary>
        /// The date and start time of the opening night.
        /// </summary>
        public DateTime OpeningNight { get; set; }

        /// <summary>
        /// The date and start time of the last night.
        /// </summary>
        public DateTime LastNight { get; set; }
    }
}
