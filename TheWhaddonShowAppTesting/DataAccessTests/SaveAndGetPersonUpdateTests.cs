using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowTesting.Tests
{
    public class SaveAndGetPersonUpdateTests : ISaveAndGetUpdateTypeTests<PersonUpdate>
    {
        private readonly ISaveAndGetUpdateTypeTests<PersonUpdate> _testProvider;

        public SaveAndGetPersonUpdateTests(ISaveAndGetUpdateTypeTests<PersonUpdate> testProvider)
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
