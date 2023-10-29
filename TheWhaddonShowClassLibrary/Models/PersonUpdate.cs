using MyClassLibrary.LocalServerMethods.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TheWhaddonShowClassLibrary.Models
{
	/// <summary>
	/// A person taking part in the show. (or previous participant if inActive)
	/// </summary>
	public class PersonUpdate : LocalServerModelUpdate
	{
		[Required]
		/// <summary>
		/// The First Name of the person.
		/// </summary>
		public string FirstName { get; set; } = string.Empty;

		/// <summary>
		/// The Last Name of the Person
		/// </summary>
		public string? LastName { get; set; }

		[EmailAddress]
		/// <summary>
		/// The email of the Person
		/// </summary>
		public string? Email { get; set; }
		/// <summary>
		/// A file path to the picture used within the app for the person.
		/// </summary>
		public string? PictureRef { get; set; }
		/// <summary>
		/// Identifies if the person is an actor. (available to be allocated to Parts)
		/// </summary>
		public bool IsActor { get; set; } = false;
		/// <summary>
		/// Identifies if the person is a singer. (available to be allocated to Singing Parts)
		/// </summary>
		public bool IsSinger { get; set; } = false;
		/// <summary>
		/// Identifies if the person is a writer. (able to edit the Script)
		/// </summary>
		public bool IsWriter { get; set; } = false;
		/// <summary>
		/// Identifies if the person is in the Band.
		/// </summary>
		public bool IsBand { get; set; } = false;
		/// <summary>
		/// Identifies if the person is part of the technical team.
		/// </summary>
		public bool IsTechnical { get; set; } = false;
		/// <summary>
		/// Identifies if the person is an admin. (able to access everything in Whaddon Show App)
		/// </summary>
		public bool IsAdmin { get; set; } = false;
		/// <summary>
		/// Tags relevant to the person which can be matched with other models or used for filtering.
		/// </summary>
		public List<string>? Tags { get; set; }


		public PersonUpdate()
		{

		}

		public PersonUpdate(Guid id, string firstName, string? lastName = null, string? email = null, string? pictureRef = null, bool? isActor = null,
		   bool? isSinger = null, bool? isWriter = null, bool? isBand = null, bool? isTechnical = null, bool? isAdmin = null, List<string>? tags = null) : base(id)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			PictureRef = pictureRef;
			IsActor = isActor ?? false;
			IsSinger = isSinger ?? false;
			IsWriter = isWriter ?? false;
			IsBand = isBand ?? false;
			IsTechnical = isTechnical ?? false;
			IsAdmin = isAdmin ?? false;
			Tags = tags ?? new List<string>();
		}

		[JsonConstructor]
		public PersonUpdate(Guid id, DateTime created, string createdBy, DateTime? updatedOnServer, bool isConflicted, bool isSample, bool isActive
							, string firstName, string? lastName, string? email, string? pictureRef
							, bool isActor, bool isSinger, bool isWriter, bool isBand, bool isTechnical, bool isAdmin
							, List<string>? tags) : base(id)
		{
			Id = id;
			Created = created;
			CreatedBy = createdBy;
			UpdatedOnServer = updatedOnServer;
			IsConflicted = isConflicted;
			IsSample = isSample;
			IsActive = isActive;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			PictureRef = pictureRef;
			IsActor = isActor;
			IsSinger = isSinger;
			IsWriter = isWriter;
			IsBand = isBand;
			IsTechnical = isTechnical;
			IsAdmin = isAdmin;
			Tags = tags ?? new List<string>();
		}
	}
}
