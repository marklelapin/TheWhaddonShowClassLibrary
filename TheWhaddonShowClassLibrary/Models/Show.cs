using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    internal class Show
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// The date and start time of the opening night.
        /// </summary>
        public DateTime OpeningNight { get; set; }
        /// <summary>
        /// The date and start time of the last night.
        /// </summary>
        public DateTime LastNight { get; set;}

        /// <summary>
        /// The ScriptItem at the top of the script heirachy for the show.
        /// </summary>
        ScriptItemUpdate? ScriptHead { get; set; }


        public Show(string title)
        {
            Title = title;
            ScriptHead = new ScriptItemUpdate(null,1,"Show",null,null);
        }


    }
}
