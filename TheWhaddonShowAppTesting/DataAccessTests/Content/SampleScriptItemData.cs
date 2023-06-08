using MyClassLibrary.LocalServerMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowTesting.Tests.Content
{
    internal class SampleScriptItemData
    {
        internal static List<ScriptItemUpdate> LocalStartingData { get { return StartingData(); } }

        internal static List<ScriptItemUpdate> ServerStartingData { get { return StartingData(); } }

        internal static List<ServerSyncLog> ServerSyncLogStartingData = new List<ServerSyncLog> { };

        private static List<ScriptItemUpdate> StartingData()
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
                , null
                , 1
                , "Scene"
                , "Husband Greets Wife"
                , new List<Guid>() { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5"), Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B") }
                , new List<string>() { "Test" }
                ),
            new ScriptItemUpdate(Guid.Parse("FC97305D-8A92-42D5-94DB-6FC9F5FF1432")
                , DateTime.Parse("2023-04-19 07:55:59.1345654")
                , "Mark Carter"
                , DateTime.Parse("2023-04-19 07:56:00.9436483")
                , false
                , true
                , true
                , Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
                , 1
                , "Dialogue"
                , "Hello Ms Test."
                , new List<Guid>() { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5") }
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
                , Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
                , 2
                , "Dialogue"
                , "Good Morning Mr Test"
                , new List<Guid>() { Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B") }
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
                , Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197")
                , 3
                , "Dialogue"
                , "Would you like a cup of coffee?"
                , new List<Guid>() { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5") }
                , new List<string>() { "Test" }
                ),
              new ScriptItemUpdate(
                Guid.Parse("CD42AD02-CC02-4AA4-8AB6-8C4ACB2E9858"),
                DateTime.Parse("2023-04-19 07:56:02.2355654"),
                "Mark Carter",
                DateTime.Parse("2023-04-19 07:56:03.9436483"),
                false,
                true,
                true,
                Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197"),
                4,
                "Dialogue",
                "Yes please! Two sugars, milk and a drop of baileys.",
                new List<Guid> { Guid.Parse("17822466-DD66-4F2D-B4A9-F7EAAD6EB08B") },
                new List<string> { "Test" }
            ),
            new ScriptItemUpdate(
                Guid.Parse("10DD3D80-5853-424B-999D-FB758565B03E"),
                DateTime.Parse("2023-04-19 07:56:02.1345654"),
                "Mark Carter",
                DateTime.Parse("2023-04-19 07:56:03.9436483"),
                false,
                true,
                true,
                Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197"),
                5,
                "Dialogue",
                "Isnt it a bit early for that?",
                new List<Guid> { Guid.Parse("68417C12-80C3-48BC-8EBE-3F3F2A91B8E5") },
                new List<string> { "Test" }
            ),
            new ScriptItemUpdate(
                Guid.Parse("ED789FA3-4B2B-41A0-A322-773ED7CE89FE"),
                DateTime.Parse("2023-04-19 07:56:10.1345654"),
                "Mark Carter",
                DateTime.Parse("2023-04-19 07:56:11.4675483"),
                false,
                true,
                true,
                Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197"),
                6,
                "Action",
                "(audience laughs)",
                null,
                new List<string> { "Test" }
            ),
            new ScriptItemUpdate(
                 Guid.Parse("ED789FA3-4B2B-41A0-A322-773ED7CE89FE"),
                 DateTime.Parse("2023-04-19 07:56:12.1345654"),
                 "Mark Carter",
                 DateTime.Parse("2023-04-19 07:56:13.9436483"),
                 false,
                 true,
                 true,
                 Guid.Parse("0DE2C9A4-41F7-4170-9BDF-04B7B8F64197"),
                 6,
                 "Action",
                 "(audience laughs tepidly and suspects they should have stayed at home.)",
                 null,
                 new List<string> { "Test" }
             )


        };

            return scriptItemUpdates;

        }
    }
}
