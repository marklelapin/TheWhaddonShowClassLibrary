using MyClassLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// Intermediary Class used to convert ids saved against ScriptItem into full objects.
    /// </summary>
    internal class ScriptItemDataAccess
    {

        /// <summary>
        /// The identity of the Script Item in the Script History Table.
        /// </summary>
        internal int Id { get; set; }
        /// <summary>
        /// The parent script Item ID of this script item.
        /// </summary>
        internal int? ParentId { get; set; }
        /// <summary>
        /// The order no in which this appears amongst other items with the same Parent
        /// </summary>
        internal int OrderNo { get; set; }
        /// <summary>
        /// The type of script item this is i.e Show, Act, Scene, Line, Paragraph or Span 
        /// </summary>
        internal int TypeID { get; set; }

        /// <summary>
        /// Comma Separated List of Part IDs
        /// </summary>
        internal string PartIdsCSV { get; set; }

        /// <summary>
        /// The time and date at which the user made changes within the app.
        /// </summary>
        internal DateTime UpdatedInApp { get; set; }
        /// <summary>
        /// The time and date at which the SQL Script History table was last updatd.
        /// </summary>
        internal DateTime UpdateInHistory { get; set; }

        /// <summary>
        /// PersonID of the user who updated the script
        /// </summary>
        internal int UpdatedByPersonId { get; set; }
        /// <summary>
        /// A guid given to the Script Item along with another Script Item where there is a conflict when merging.
        /// </summary>
        internal Guid ConflictID { get; set; }

        /// <summary>
        /// List of string that can be used as tags.
        /// </summary>
        internal string TagsCSV { get; set; }

        public ScriptItemDataAccess(ScriptItem scriptItem)
        {
            Id = scriptItem.Id;
            ParentId = scriptItem.Parent.GetId();
            OrderNo = scriptItem.OrderNo;
            TypeID = scriptItem.Type.GetId() ?? ;
            if (scriptItem.Parts.Count > 0 )
            {
                    PartIdsCSV = string.Join(",",scriptItem.Parts.Select(x => x.Id.ToString()).ToArray());
            } else
            {
                PartIdsCSV = string.Empty;
            }
            UpdatedInApp = scriptItem.UpdatedInApp;
            UpdateInHistory = scriptItem.UpdateInHistory;
            UpdatedByPersonId = scriptItem.UpdatedBy.GetId();
            ConflictID = scriptItem.ConflictID;
            if (scriptItem.Tags.Count > 0 )
            {
                TagsCSV = string.Join(",",scriptItem.Tags);
            } else
            {
                TagsCSV = string.Empty;
            }
            
        }
    }
}
