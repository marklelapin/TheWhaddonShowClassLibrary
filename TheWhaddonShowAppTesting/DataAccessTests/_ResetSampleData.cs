
using MyClassLibrary.LocalServerMethods.Interfaces;
using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowTesting.Tests.Content;

namespace TheWhaddonShowTesting.Tests
{
    public class _ResetSampleData
    {
       
            private readonly ILocalDataAccess<PartUpdate> _localPartDataAccess;
            private readonly IServerDataAccess<PartUpdate> _serverPartDataAccess;
            private readonly ILocalDataAccess<PersonUpdate> _localPersonDataAccess;
            private readonly IServerDataAccess<PersonUpdate> _serverPersonDataAccess;
            private readonly ILocalDataAccess<ScriptItemUpdate> _localScriptItemDataAccess;
            private readonly IServerDataAccess<ScriptItemUpdate> _serverScriptItemDataAccess;

            public _ResetSampleData(
                                    ILocalDataAccess<PartUpdate> localPartDataAccess
                                    ,   IServerDataAccess<PartUpdate> serverPartDataAccess
                                    ,ILocalDataAccess<PersonUpdate> localPersonDataAccess
                                    ,   IServerDataAccess<PersonUpdate> serverPersonDataAccess
                                    ,ILocalDataAccess<ScriptItemUpdate> localScriptItemDataAccess
                                    ,   IServerDataAccess<ScriptItemUpdate> serverScriptItemDataAccess
                                    )
            {
                _localPartDataAccess = localPartDataAccess;
                _serverPartDataAccess = serverPartDataAccess;

                _localPersonDataAccess = localPersonDataAccess;
                _serverPersonDataAccess = serverPersonDataAccess;

                _localScriptItemDataAccess = localScriptItemDataAccess;
                _serverScriptItemDataAccess = serverScriptItemDataAccess;
            }

            [Fact]
            public async void ResetTest()
            {

                await _localPartDataAccess.ResetSampleData(SamplePartData.LocalStartingData);
                await _serverPartDataAccess.ResetSampleData(SamplePartData.ServerStartingData,SamplePartData.ServerSyncLogStartingData);

                await _localPersonDataAccess.ResetSampleData(SamplePersonData.LocalStartingData);
                await _serverPersonDataAccess.ResetSampleData(SamplePersonData.ServerStartingData, SamplePersonData.ServerSyncLogStartingData);

                await _localScriptItemDataAccess.ResetSampleData(SampleScriptItemData.LocalStartingData);
                await _serverScriptItemDataAccess.ResetSampleData(SampleScriptItemData.ServerStartingData, SampleScriptItemData.ServerSyncLogStartingData);


                Assert.True(true); //This isn't a test - it is designed to be run before testing all to reset the Sample Data in the database.
            }


        
    }

}
