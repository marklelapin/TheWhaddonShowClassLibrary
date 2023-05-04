using MyClassLibrary.Interfaces;
using MyClassLibrary.LocalServerMethods;
using Newtonsoft.Json;
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
    public class ScriptItemUpdate : LocalServerIdentityUpdate, IHasParentId<Guid>
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
        /// Title of the scene, piece of dialogue, action description etc...
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// List of Parts associated with the script item. If null defaults to 
        /// </summary>
        public List<Guid>? PartIds { get; }

        /// <summary>
        /// List of string that can be used as tags.
        /// </summary>
        public List<string> Tags { get; set; }
     

        public ScriptItemUpdate(Guid id, Guid? parentId, int orderNo, string type, List<Part>? parts = null, List<string>? tags = null) : base(id)
        {
            ParentId = parentId ?? Guid.Empty;
            OrderNo = orderNo;
            Type = type;
            if (parts == null)
            {
                PartIds = new List<Guid>();
            }
            else
            {
                foreach (Guid guid in parts.Select(x => x.Id).ToList())
                {
                    throw new NotImplementedException(); //validateParts(guid);
                } 
            }
            if (validateType(type)) Type = type;
            Tags = tags ?? new List<string>();
            
        }

        [JsonConstructor]
        public ScriptItemUpdate(Guid id, DateTime created, string createdBy, DateTime? updatedOnServer, bool isActive, Guid? parentId, int orderNo, string type, List<Guid>? parts = null, List<string>? tags = null) : base(id)
        {
            Id= id;
            Created = created;
            CreatedBy = createdBy;
            UpdatedOnServer = updatedOnServer;
            IsActive = isActive;
            ParentId = parentId ?? Guid.Empty;
            OrderNo = orderNo;
            if (validateType(type)) Type = type;
            PartIds = parts ;
            Tags = tags ?? new List<string>();  

        }



        private bool validateType(string type)
        {
            if (!CategoryLists.ScriptItemTypes.Contains(type))
            {
                throw new ArgumentException(@$"Invalid scriptItemType of '{type}' passed into ScriptItem constructor.");
            }

            return true;
        }

        private bool validateParts(List<Guid> parts)
        {
            throw new NotImplementedException("inavlid part id passed in");
        }


        public List<Part> Parts() {
            throw new NotImplementedException();
                }

    }
}
