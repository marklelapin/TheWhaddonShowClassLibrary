using MyClassLibrary.Interfaces;
using MyClassLibrary.Methods;
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
    public class ScriptItemUpdate : LocalServerIdentity, IHasParentId<Guid>
    {
        /// <summary>
        /// The Id of the parent script Item of this script item.
        /// </summary>
        public Guid ParentId { get; set; }
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
        public List<Part> Parts { get; }

        /// <summary>
        /// List of string that can be used as tags.
        /// </summary>
        public List<string> Tags { get; set; }
     

        public ScriptItemUpdate(Guid? parentId, int orderNo, string type, List<Part>? parts = null, List<string>? tags = null) : base()
        {
            ParentId = parentId ?? Guid.Empty;
            OrderNo = orderNo;
            Type = type;
            Parts = parts ?? new List<Part>();
            if (validateType(type)) Type = type;
            Tags = tags ?? new List<string>();
            
        }

        public ScriptItemUpdate(ScriptItemUpdate scriptItemUpdate,Guid? parentId, int orderNo, string type, List<Part>? parts = null, List<string>? tags = null) : base(scriptItemUpdate.Id)
        {
            ParentId = parentId ?? Guid.Empty;
            OrderNo = orderNo;
            Parts = parts ?? new List<Part>();
            if (validateType(type)) Type = type;
            Tags = tags ?? new List<string>();
        }


        public ScriptItemUpdate(ScriptItemUpdate scriptItemUpdate, bool isActive) : base(scriptItemUpdate.Id,isActive)
        {
            ParentId = scriptItemUpdate.ParentId;
            OrderNo = scriptItemUpdate.OrderNo;
            Parts = scriptItemUpdate.Parts;
            Type = scriptItemUpdate.Type;
            Tags = scriptItemUpdate.Tags;
        }


        private bool validateType(string type)
        {
            if (!CategoryLists.ScriptItemTypes.Contains(type))
            {
                throw new ArgumentException(@$"Invalid scriptItemType of '{type}' passed into ScriptItem constructor.");
            }

            return true;
        }


    }
}
