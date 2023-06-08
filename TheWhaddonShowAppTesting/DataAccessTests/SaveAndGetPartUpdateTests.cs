using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowTesting.Tests
{
    public class SaveAndGetPartUpdateTests : ISaveAndGetUpdateTypeTests<PartUpdate>
    {
        private readonly ISaveAndGetUpdateTypeTests<PartUpdate> _testProvider;

        public SaveAndGetPartUpdateTests(ISaveAndGetUpdateTypeTests<PartUpdate> testProvider)
        {
            _testProvider = testProvider;
        }

        [Fact]
        public async Task SaveAndGetLocalTest()
        {
           await _testProvider.SaveAndGetLocalTest();
        }

        [Fact]
        public async Task SaveAndGetServerTest()
        {
            await _testProvider.SaveAndGetServerTest();
        }
    }
}
