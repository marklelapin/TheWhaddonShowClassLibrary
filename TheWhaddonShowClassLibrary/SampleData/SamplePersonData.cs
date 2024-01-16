using MyClassLibrary.LocalServerMethods.Models;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.SampleData
{
	public class SamplePersonData
	{

		public static List<PersonUpdate> LocalStartingData { get { return StartingData(); } }

		public static List<PersonUpdate> ServerStartingData { get { return StartingData(); } }

		public static List<ServerSyncLog> ServerSyncLogStartingData = new List<ServerSyncLog>
		{
        // Only these synced to CopyID2
            new ServerSyncLog(
				Guid.Parse("545A9495-DB58-44EC-BA47-FD0B7E478D4A")
				, DateTime.Parse("2023-05-22 10:03:58.1345654")
				, TestContent.CopyId2
				),
			new ServerSyncLog(
				Guid.Parse("2B3FA075-D0B5-49AB-B897-DAB1428CA500")
				, DateTime.Parse("2023-05-19 09:05:58.8453258")
				, TestContent.CopyId2
				),
			new ServerSyncLog(
				Guid.Parse("2B3FA075-D0B5-49AB-B897-DAB1428CA500")
				, DateTime.Parse("2023-05-21 09:05:58.8453258")
				, TestContent.CopyId2
				),
			new ServerSyncLog(
				Guid.Parse("2B3FA075-D0B5-49AB-B897-DAB1428CA500")
				, DateTime.Parse("2023-05-21 09:06:58.8453258")
				, TestContent.CopyId2
				)
		};

		public static List<PersonUpdate> StartingData()
		{

			List<PersonUpdate> personUpdates = new List<PersonUpdate>()
					{
						new PersonUpdate(
							Guid.Parse("545A9495-DB58-44EC-BA47-FD0B7E478D4A")
							, DateTime.Parse("2023-05-22 10:03:58.1345654")
							, "Mark Carter"
							, DateTime.Parse("2023-05-22 10:05:48.9436483")
							, false
							, true
							, true
							, "Bob"
							, "Blair"
							, "bob.blair@thisisnotarealemail.com"
							, "/images/picture.png"
							, true
							, false
							, false
							, false
							, false
							,false
							, new List<string>(){"Test","Male"}
							, null
							),
						new PersonUpdate(
							Guid.Parse("2B3FA075-D0B5-49AB-B897-DAB1428CA500")
							, DateTime.Parse("2023-05-19 09:05:58.8453258")
							, "Mark Carter"
							, DateTime.Parse("2023-05-19 10:04:48.6789658")
							, false
							, true
							, true
							, "Sue"
							, "Smith"
							, "sue.smith@fakeemail.com"
							, "/images/picture3.png"
							, true
							, false
							, false
							, false
							, false
							,false
							, new List<string>(){"Test","Female"}
							, null
							),
						new PersonUpdate(
							Guid.Parse("2B3FA075-D0B5-49AB-B897-DAB1428CA500")
							, DateTime.Parse("2023-05-21 09:05:58.8453258")
							, "Mark Carter"
							, DateTime.Parse("2023-05-21 10:04:48.6789658")
							, true
							, true
							, true
							, "Carol"
							, "Conflicted"
							, "sue.smith@fakeemail.com"
							, "/images/picture3.png"
							, true
							, true
							, true
							, true
							, true
							,false
							, new List<string>(){"Test","Female"}
							, "gggggg"
							),
						new PersonUpdate(
							Guid.Parse("2B3FA075-D0B5-49AB-B897-DAB1428CA500")
							, DateTime.Parse("2023-05-21 09:06:58.8453258")
							, "Mark Carter"
							, DateTime.Parse("2023-05-21 10:05:00.6789658")
							, true
							, true
							, true
							, "Carol"
							, "Conflicted"
							, "sue.smith@fakeemail.com"
							, "/images/picture3.png"
							, true
							, false
							, false
							, false
							, false
							,false
							, new List<string>(){"Test","Female"}
							, "gggggg"
							)
					};

			return personUpdates;
		}
	}
}
