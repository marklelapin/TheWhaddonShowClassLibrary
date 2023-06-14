
using MyClassLibrary.LocalServerMethods.Interfaces;
using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowClassLibrary.SampleData;

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
            private readonly ILocalDataAccess<TagUpdate> _localTagDataAccess;
            private readonly IServerDataAccess<TagUpdate> _serverTagDataAccess;

            public _ResetSampleData(
                                    ILocalDataAccess<PartUpdate> localPartDataAccess
                                    ,   IServerDataAccess<PartUpdate> serverPartDataAccess
                                    ,ILocalDataAccess<PersonUpdate> localPersonDataAccess
                                    ,   IServerDataAccess<PersonUpdate> serverPersonDataAccess
                                    ,ILocalDataAccess<ScriptItemUpdate> localScriptItemDataAccess
                                    ,   IServerDataAccess<ScriptItemUpdate> serverScriptItemDataAccess
                                    ,ILocalDataAccess<TagUpdate> localTagDataAccess
                                    ,   IServerDataAccess<TagUpdate> serverTagDataAccess
                                    )
            {
                _localPartDataAccess = localPartDataAccess;
                _serverPartDataAccess = serverPartDataAccess;

                _localPersonDataAccess = localPersonDataAccess;
                _serverPersonDataAccess = serverPersonDataAccess;

                _localScriptItemDataAccess = localScriptItemDataAccess;
                _serverScriptItemDataAccess = serverScriptItemDataAccess;

                _localTagDataAccess = localTagDataAccess;
                _serverTagDataAccess = serverTagDataAccess;
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

                await _localTagDataAccess.ResetSampleData(SampleTagData.LocalStartingData);
                await _serverTagDataAccess.ResetSampleData(SampleTagData.ServerStartingData, SampleTagData.ServerSyncLogStartingData);

            Assert.True(true); //This isn't a test - it is designed to be run before testing all to reset the Sample Data in the database.
            }


        
    }

}
