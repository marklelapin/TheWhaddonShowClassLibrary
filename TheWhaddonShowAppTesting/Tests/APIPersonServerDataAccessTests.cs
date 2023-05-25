using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Services;
using MyClassLibrary.Tests.LocalServerMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowTesting.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyClassLibrary.LocalServerMethods.Models;

namespace TheWhaddonShowTesting.Tests
{
    public class APIPersonServerDataAccessTests
    {
        
        
        private static IServiceConfiguration<PersonUpdate> _serviceConfiguration = new APITestServiceConfiguration<PersonUpdate>();
        
        private static IServerDataAccessTests<PersonUpdate> _serverDataAccessTests = _serviceConfiguration.ServerDataAccessTests();
        

        public static object[][] SaveTestData = _serverDataAccessTests.SaveTestData();
        [Theory, MemberData(nameof(SaveTestData))]
        public void SaveTest(List<PersonUpdate> personUpdates)
        {
            _serverDataAccessTests.SaveTest(personUpdates);
        }


        public static readonly object[][] SaveAndGetTestData = _serverDataAccessTests.SaveAndGetTestData();
        [Theory, MemberData(nameof(SaveAndGetTestData))]
        public void SaveAndGetTest(List<PersonUpdate> personUpdates, List<Guid> getIds, List<PersonUpdate> expected)
        {
            _serverDataAccessTests.SaveAndGetTest(personUpdates, getIds, expected);
        }


        public static readonly object[][] GetChangesTestData = _serverDataAccessTests.GetChangesTestData();
        [Theory, MemberData(nameof(GetChangesTestData))]
        public void GetChangesTest(List<PersonUpdate> personUpdates, int lastSyncDateAdjustment, List<PersonUpdate> expected)
        {
            _serverDataAccessTests.GetChangesTest(personUpdates, lastSyncDateAdjustment, expected);
        }


        public static readonly object[][] SaveConflictIdTestData = _serverDataAccessTests.SaveConflictIdTestData();
        [Theory, MemberData(nameof(SaveConflictIdTestData))]
        public void SaveConflictIdTest(List<PersonUpdate> personUpdate, List<Conflict> conflicts, List<Conflict> expected)
        {
            _serverDataAccessTests.SaveConflictIdTest(personUpdate, conflicts, expected);
        }



        //TODO add in Delete Test when funcionality is setup
        //public static readonly object[][] DeleteTestData = _serverDataAccessTests.DeleteTestData();
        //[Theory,MemberData(nameof(DeleteTestData))]
        //public void DeleteTest(List<PersonUpdate> personUpdatesToDelete)
        //{
        //   _serverDataAccessTests.DeleteTest(personUpdatesToDelete);
        //}



    }



}

