using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowClassLibrary.SampleData;

namespace TheWhaddonShowTesting.DataAccessTests.Content
{
    internal class SaveAndGetPartUpdateTestContent : ISaveAndGetTestContent<PartUpdate>
    {
        public Guid CopyId => TestContent.CopyId;

        public List<PartUpdate> GetNewUpdates()
        {

            List<PartUpdate> output = SamplePartData.LocalStartingData;

            output.ForEach(update =>
           {
               update.Id = Guid.NewGuid();
               update.UpdatedOnServer = null;

           });

            return output;
        }

    }
}
