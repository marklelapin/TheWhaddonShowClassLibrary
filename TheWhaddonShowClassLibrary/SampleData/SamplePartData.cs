using MyClassLibrary.LocalServerMethods.Models;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.SampleData
{
	public static class SamplePartData
	{
		public static List<PartUpdate> LocalStartingData { get { return StartingData(); } }

		public static List<PartUpdate> ServerStartingData { get { return StartingData(); } }

		public static List<ServerSyncLog> ServerSyncLogStartingData = new List<ServerSyncLog>
		{
         // Only these synced to CopyID
            new ServerSyncLog(
					Guid.Parse("F380FD46-6E6E-450D-AD3E-23EEC0B6A75E"),
					DateTime.Parse("2023-04-19 09:08:58.3745924"),
				   TestContent.CopyId
				),
				new ServerSyncLog(
					 Guid.Parse("F380FD46-6E6E-450D-AD3E-23EEC0B6A75E"),
					 DateTime.Parse("2023-04-21 09:08:58.3745924"),
					TestContent.CopyId
				 ),
        //  All Local Starting Data synced to CopyId2
            new ServerSyncLog(
					Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5"),
					DateTime.Parse("2023-04-19 08:03:58.8431658"),
					TestContent.CopyId2

				),
				new ServerSyncLog(
					Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B"),
					DateTime.Parse("2023-04-19 09:05:58.8453258"),
					TestContent.CopyId2
				),
				new ServerSyncLog(
					Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B"),
					DateTime.Parse("2023-04-21 12:58:23.5628451"),
					TestContent.CopyId2
				),
				new ServerSyncLog(
					Guid.Parse("F380FD46-6E6E-450D-AD3E-23EEC0B6A75E"),
					DateTime.Parse("2023-04-19 09:08:58.3745924"),
				   TestContent.CopyId2
				),
				new ServerSyncLog(
					 Guid.Parse("F380FD46-6E6E-450D-AD3E-23EEC0B6A75E"),
					 DateTime.Parse("2023-04-21 09:08:58.3745924"),
					TestContent.CopyId2
				 )

		};

		public static List<PartUpdate> StartingData()
		{
			List<PartUpdate> partUpdates = new List<PartUpdate>
			{
				new PartUpdate(
					Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5"),
					DateTime.Parse("2023-04-19 08:03:58.8431658"),
					"Mark Carter",
					DateTime.Parse("2023-04-19 08:05:48.5671658"),
					false,
					true,
					true,
					"Mr Test",
					Guid.Parse("545A9495-DB58-44EC-BA47-FD0B7E478D4A"),
					new List<string> { "Test", "Male" }
				),
				new PartUpdate(
					Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B"),
					DateTime.Parse("2023-04-19 09:05:58.8453258"),
					"Mark Carter",
					DateTime.Parse("2023-04-19 10:04:48.6789658"),
					false,
					true,
					true,
					"Ms Test",
					null,
					new List<string> { "Test", "Female", "Singing" }
				),
				new PartUpdate(
					Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B"),
					DateTime.Parse("2023-04-21 12:58:23.5628451"),
					"Guy Birch",
					DateTime.Parse("2023-04-21 13:01:48.9805643"),
					false,
					true,
					true,
					"Ms Test",
					Guid.Parse("2B3FA075-D0B5-49AB-B897-DAB1428CA500"),
					new List<string> { "Test", "Female", "Singing" }
				),
				new PartUpdate(
					Guid.Parse("F380FD46-6E6E-450D-AD3E-23EEC0B6A75E"),
					DateTime.Parse("2023-04-19 09:08:58.3745924"),
					"Mark Carter",
					DateTime.Parse("2023-04-19 10:04:49.4562984"),
					true,
					true,
					true,
					"Uncle Test",
					null,
					new List<string> { "Test", "Male", "Singing" }
				),
				new PartUpdate(
					 Guid.Parse("F380FD46-6E6E-450D-AD3E-23EEC0B6A75E"),
					 DateTime.Parse("2023-04-21 09:08:58.3745924"),
					 "Guy Birch",
					 DateTime.Parse("2023-04-21 10:04:49.4562984"),
					 true,
					 false,
					 true,
					 "Uncle Test",
					 null,
					 new List<string> { "Test", "Male", "Singing" }
				 )
			};

			return partUpdates;
		}

	}
}
