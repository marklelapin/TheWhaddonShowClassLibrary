using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowTesting.Tests.Content
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
