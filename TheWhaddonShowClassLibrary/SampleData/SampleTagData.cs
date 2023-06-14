
using MyClassLibrary.LocalServerMethods.Models;
using MyClassLibrary.Tests.LocalServerMethods.Tests;

using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.SampleData
{
   public static class SampleTagData
    {
        public static List<TagUpdate> LocalStartingData { get { return StartingData(); } }

        public static List<TagUpdate> ServerStartingData { get { return StartingData(); } }

        public static List<ServerSyncLog> ServerSyncLogStartingData = new List<ServerSyncLog>();
    
        public static List<TagUpdate> StartingData()
        {
            List<TagUpdate> tagUpdates = new List<TagUpdate>
            {
                new TagUpdate("Male",Guid.NewGuid())
                ,new TagUpdate("Female",Guid.NewGuid())
                , new TagUpdate("Test", Guid.NewGuid()  )
                ,new TagUpdate("Singing", Guid.NewGuid()    )
              
            };

            return tagUpdates;
        }

    }
}
