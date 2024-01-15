
using MyClassLibrary.LocalServerMethods.Models;
using System.Text.Json.Serialization;

namespace TheWhaddonShowClassLibrary.Models
{
	/// <summary>
	/// Base Class for all ScriptItems
	/// </summary>
	public class ScriptItemUpdate : LocalServerModelUpdate//, IHasParentId<Guid>
	{
		/// <summary>
		/// The Id of the parent script Item of this script item.
		/// </summary>
		public Guid? ParentId { get; set; }

		/// <summary>
		/// The type of script item this is i.e Show, Act, Scene, Line, Paragraph or Span 
		/// </summary>
		/// [Required]
		//[RegularExpression("Show|Act|Scene|Synopsis|Dialogue|Action|Lighting|Sound|Staging|InitialStaging|Curtain|InitialCurtain|Comment"
		//				   , ErrorMessage = "An invalid scriptItemType was given.\n" +
		//					"Valid Types:  - Show|Act|Scene|Synopsis|Dialogue|Action|Lighting|Sound|Staging|InitialStaging|Curtain|InitialCurtain|Comment")]
		public string Type { get; set; } = string.Empty;


		/// <summary>
		/// Title of the scene, piece of dialogue, action description etc...
		/// </summary>
		public string Text { get; set; } = string.Empty;

		/// <summary>
		/// List of Parts associated with the script item. If null defaults to 
		/// </summary>
		public List<Guid>? PartIds { get; set; }


		/// <summary>
		/// The id of the next script item in the script.
		/// </summary>
		public Guid? NextId { get; set; } = null;

		/// <summary>
		/// The id of the previous script item in the script.
		/// </summary>
		public Guid? PreviousId { get; set; } = null;

		/// <summary>
		/// The id of the comment script item associated with this script item.
		/// </summary>
		public Guid? CommentId { get; set; } = null;

		/// <summary>
		/// a list of file or youTube urls attached to this script item.
		/// </summary>
		public List<string> Attachments { get; set; } = new List<string>();

		/// <summary>
		/// List of string that can be used as tags.
		/// </summary>
		public List<string>? Tags { get; set; }

		public ScriptItemUpdate()
		{

		}

		public ScriptItemUpdate(string type) : base(Guid.NewGuid())
		{
			Type = type;
		}

		public ScriptItemUpdate(Guid id, Guid? parentId, string type, List<PartUpdate>? partUpdates = null, List<string>? tags = null) : base(id)
		{
			ParentId = parentId ?? Guid.Empty;
			PartIds = partUpdates?.Select(x => x.Id).ToList();
			Type = type;
			Tags = tags;

		}


		[JsonConstructor]
		public ScriptItemUpdate(Guid id, DateTime created, string createdBy, DateTime? updatedOnServer,
			bool isConflicted, bool isSample, bool isActive,
			string type, string text, List<Guid>? partIds,
			Guid? parentId, Guid? nextId, Guid? previousId, Guid? commentId, List<string> attachments,
			List<string>? tags = null) : base(id)
		{
			Id = id;
			Created = created;
			CreatedBy = createdBy;
			UpdatedOnServer = updatedOnServer;
			IsConflicted = isConflicted;
			IsSample = isSample;
			IsActive = isActive;
			Type = type;
			Text = text;
			PartIds = partIds;
			ParentId = parentId;
			NextId = nextId;
			PreviousId = previousId;
			CommentId = commentId;
			Attachments = attachments;

			Tags = tags;

		}



		public List<Part> Parts()
		{
			throw new NotImplementedException();
		}

	}
}
