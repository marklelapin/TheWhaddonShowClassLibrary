using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowClassLibrary.SampleData;

namespace TheWhaddonShowTesting.DataAccessTests.Content
{
    internal class SaveAndGetPersonUpdateTestContent : ISaveAndGetTestContent<PersonUpdate>
    {

        public Guid CopyId => TestContent.CopyId;

        public List<PersonUpdate> GetNewUpdates()
        {

            List<PersonUpdate> output = SamplePersonData.LocalStartingData;

            output.ForEach(update =>
            {
                update.Id = Guid.NewGuid();
                update.UpdatedOnServer = null;
            });

            return output;
        }
    }
}
