using MyClassLibrary.Extensions;
using MyClassLibrary.Interfaces;
using MyClassLibrary.LocalServerMethods;
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
    internal class ScriptItemUpdateDataAccess : LocalServerIdentity, IHasParentId<Guid>
    {
        /// <summary>
        /// The parent script Item ID of this script item.
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// The order no in which this appears amongst other items with the same Parent
        /// </summary>
        internal int OrderNo { get; set; }
        /// <summary>
        /// The type of script item this is i.e Show, Act, Scene, Line, Paragraph or Span 
        /// </summary>
        internal string Type { get; set; }

        /// <summary>
        /// Comma Separated List of Part IDs
        /// </summary>
        internal string PartIdsCSV { get; set; }

        /// <summary>
        /// List of string that can be used as tags.
        /// </summary>
        internal string TagsCSV { get; set; }

        public ScriptItemUpdateDataAccess(ScriptItemUpdate scriptItemUpdate)
        {
            Id = scriptItemUpdate.Id;
            ParentId = scriptItemUpdate.ParentId;
            OrderNo = scriptItemUpdate.OrderNo;
            Type = scriptItemUpdate.Type;
            if (scriptItemUpdate.Parts.Count > 0 )
            {
                    PartIdsCSV = string.Join(",",scriptItemUpdate.Parts.Select(x => x.Id.ToString()).ToArray());
            } else
            {
                PartIdsCSV = string.Empty;
            }
            if (scriptItemUpdate.Tags.Count > 0 )
            {
                TagsCSV = string.Join(",",scriptItemUpdate.Tags);
            } else
            {
                TagsCSV = string.Empty;
            }
            IsActive = scriptItemUpdate.IsActive;
        }
    }
}
