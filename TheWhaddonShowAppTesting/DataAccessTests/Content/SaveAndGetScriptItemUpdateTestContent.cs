using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Tests;

using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowClassLibrary.SampleData;

namespace TheWhaddonShowTesting.DataAccessTests.Content
{
    internal class SaveAndGetScriptItemUpdateTestContent : ISaveAndGetTestContent<ScriptItemUpdate>
    {

        public Guid CopyId => TestContent.CopyId;

        public List<ScriptItemUpdate> GetNewUpdates()
        {

            List<ScriptItemUpdate> output = SampleScriptItemData.LocalStartingData;

            output.ForEach(update =>
            {
                update.Id = Guid.NewGuid();
                update.UpdatedOnServer = null;
            });

            return output;
        }
    }
}
