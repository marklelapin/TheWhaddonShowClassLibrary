using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// Base Class for all ScriptItems
    /// </summary>
    public class ScriptItem
    {
        /// <summary>
        /// The identity of the Script Item in the Script History Table.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The parent script Item of this script item.
        /// </summary>
        public ScriptItem Parent { get; set; }
        /// <summary>
        /// The order no in which this appears amongst other items with the same Parent
        /// </summary>
        public int OrderNo { get; set; }
        /// <summary>
        /// The type of script item this is i.e Show, Act, Scene, Line, Paragraph or Span 
        /// </summary>
        public ScriptItemType Type { get; set; }
        /// <summary>
        /// The time and date at which the user made changes within the app.
        /// </summary>
        DateTime UpdatedInApp { get; set; }
        /// <summary>
        /// The time and date at which the SQL Script History table was last updatd.
        /// </summary>
        DateTime UpdateInHistory { get; set; }
        /// <summary>
        /// The user who updated the script
        /// </summary>
        public int UpdatedBy { get; set; }
        /// <summary>
        /// A guid given to the Script Item along with another Script Item where there is a conflict when merging.
        /// </summary>
        public Guid ConfictID { get; set; }

    }
}
