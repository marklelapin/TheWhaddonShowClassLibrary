﻿using MyClassLibrary.LocalServerMethods.Models;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.SampleData
{
	public class SampleScriptItemData
	{
		public static List<ScriptItemUpdate> LocalStartingData { get { return StartingData(); } }

		public static List<ScriptItemUpdate> ServerStartingData { get { return StartingData(); } }

		public static List<ServerSyncLog> ServerSyncLogStartingData = new List<ServerSyncLog>
		{
        // Only these synced to CopyID2
            new ServerSyncLog(
			   Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
				, DateTime.Parse("2023-04-19 07:55:58.1345654")
				, TestContent.CopyId2
				),
			new ServerSyncLog(
				Guid.Parse("FC97305D-8A92-42D5-94DB-6FC9F5FF1432")
				, DateTime.Parse("2023-04-19 07:55:59.1345654")
				, TestContent.CopyId2
				),
			new ServerSyncLog(
				Guid.Parse("744BD79A-1A2B-425F-874F-315A3B3BA9F2")
				, DateTime.Parse("2023-04-19 07:56:00.1345654")
				, TestContent.CopyId2
				),
			new ServerSyncLog(
				Guid.Parse("CD42AD02-CC02-4AA4-8AB6-8C4ACB2E9858"),
				DateTime.Parse("2023-04-19 07:56:02.2355654")
				, TestContent.CopyId2
				)
		};

		public static List<ScriptItemUpdate> StartingData()
		{
			List<ScriptItemUpdate> scriptItemUpdates = new List<ScriptItemUpdate>()
		   {
			new ScriptItemUpdate(
				Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
				, DateTime.Parse("2023-04-19 07:55:58.1345654")
				, "Mark Carter"
				, DateTime.Parse("2023-04-19 07:55:59.9436483")
				, false
				, true
				, true
				, "Scene"
				, "Husband Greets Wife"
				, new List<Guid>() { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5"), Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B") }
				, null
				, null
				,null
				,null
				, new List<string>() { "Test" }
				),
			new ScriptItemUpdate(Guid.Parse("FC97305D-8A92-42D5-94DB-6FC9F5FF1432") //id
                , DateTime.Parse("2023-04-19 07:55:59.1345654") //created
                , "Mark Carter" //createdBy
                , DateTime.Parse("2023-04-19 07:56:00.9436483") //updatedOnserver
                , false //isConflicted
                , true //isSample
                , true //isActive
                 , "Dialogue" //Dialogue
                , "Hello Ms Test." //Text
                , new List<Guid>() { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5") } //PartIds
                , Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197") //PArentId      
                ,null
				,null
				,null
				, new List<string>() { "Test" }
				),
			new ScriptItemUpdate(
				Guid.Parse("744BD79A-1A2B-425F-874F-315A3B3BA9F2")
				, DateTime.Parse("2023-04-19 07:56:00.1345654")
				, "Mark Carter"
				, DateTime.Parse("2023-04-19 07:56:01.9436483")
				, false
				, true
				, true
				, "Dialogue"
				, "Good Morning Mr Test"
				, new List<Guid>() { Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B") }
				, Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
				,null
				,null
				,null
				, new List<string>() { "Test" }
				),
			new ScriptItemUpdate(
				Guid.Parse("79E604CF-7CC2-41F6-B37F-F30C76AB5F34")
				, DateTime.Parse("2023-04-19 07:56:01.1345654")
				, "Mark Carter"
				, DateTime.Parse("2023-04-19 07:56:02.9436483")
				, false
				, true
				, true
				, "Dialogue"
				, "Would you like a cup of coffee?"
				, new List<Guid>() { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5") }
				, Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
				,null
				,null
				,null
				, new List<string>() { "Test" }
				),
			  new ScriptItemUpdate(
				Guid.Parse("CD42AD02-CC02-4AA4-8AB6-8C4ACB2E9858")
				,   DateTime.Parse("2023-04-19 07:56:02.2355654")
				,   "Mark Carter"
				,   DateTime.Parse("2023-04-19 07:56:03.9436483")
				,   false
				,   true
				,   true
				,   "Dialogue"
				,   "Yes please! Two sugars, milk and a drop of baileys."
				,   new List<Guid> { Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B") }
				,Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
				,null
				,null
				,null
				,new List<string> { "Test" }
			),
			new ScriptItemUpdate(
				Guid.Parse("10DD3D80-5853-424B-999D-FB758565B03E"),
				DateTime.Parse("2023-04-19 07:56:02.1345654"),
				"Mark Carter",
				DateTime.Parse("2023-04-19 07:56:03.9436483"),
				false,
				true,
				true,
				"Dialogue",
				"Isnt it a bit early for that?",
				new List<Guid> { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5") },
				Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197"),
				null,
				null,
				null,
				new List<string> { "Test" }
			),
			new ScriptItemUpdate(
				Guid.Parse("ED789FA3-4B2B-41A0-A322-773ED7CE89FE"),
				DateTime.Parse("2023-04-19 07:56:10.1345654"),
				"Mark Carter",
				DateTime.Parse("2023-04-19 07:56:11.4675483"),
				true,
				true,
				true,
				"Action",
				"(audience laughs)",
				null,
				Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197"),
				null,
				null,
				null,
				new List<string> { "Test" }
			),
			new ScriptItemUpdate(
				 Guid.Parse("ED789FA3-4B2B-41A0-A322-773ED7CE89FE"),
				 DateTime.Parse("2023-04-19 07:56:12.1345654"),
				 "Guy Birch-Jones",
				 DateTime.Parse("2023-04-19 07:56:13.9436483"),
				 true,
				 true,
				 true,
				 "Action",
				 "(audience laughs tepidly and suspects they should have stayed at home.)",
				 null,
				 Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197"),
				 null,
				 null,
				 null,
				 new List<string> { "Test" }
			 )


		};

			return scriptItemUpdates;

		}
	}
}
