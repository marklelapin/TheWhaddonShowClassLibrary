using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.StaticData;

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
        public int Id { get; set; }
        /// <summary>
        /// The parent script Item of this script item.
        /// </summary>
        public ScriptItem? Parent { get; set; }
        /// <summary>
        /// The order no in which this appears amongst other items with the same Parent
        /// </summary>
        public int OrderNo { get; set; }
        /// <summary>
        /// The type of script item this is i.e Show, Act, Scene, Line, Paragraph or Span 
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// List of Parts associated with the script item. If null defaults to 
        /// </summary>
        public List<Part>? Parts { get; set; }

        /// <summary>
        /// The time and date at which the user made changes within the app.
        /// </summary>
        public DateTime UpdatedInApp { get; set; }
        /// <summary>
        /// The time and date at which the SQL Script History table was last updatd.
        /// </summary>
        public DateTime UpdateInHistory { get; set; }

        /// <summary>
        /// The user who updated the script
        /// </summary>
        public Person? UpdatedBy { get; set; }
        /// <summary>
        /// A guid given to the Script Item along with another Script Item where there is a conflict when merging.
        /// </summary>
        public Guid ConflictID { get; set; }

        /// <summary>
        /// List of string that can be used as tags.
        /// </summary>
        public List<string>? Tags { get; set; }


        public ScriptItem(string type) //TODO Need to keep going with other parameters before this can be used
        {
            if (CategoryLists.ScriptItemTypes.Contains(type))
            {
                Type = type;
            } else
            {
                throw new ArgumentException(@$"Invalid scriptItemType of '{type}' passed into ScriptItem constructor.");
            }



            throw new NotImplementedException();
            
        }


    }
}
