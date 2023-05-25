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
    public class APIPartServerDataAccessTests
    {
        
        
        private static IServiceConfiguration<PartUpdate> _serviceConfiguration = new APITestServiceConfiguration<PartUpdate>();
        
        private static IServerDataAccessTests<PartUpdate> _serverDataAccessTests = _serviceConfiguration.ServerDataAccessTests();
        

        public static object[][] SaveTestData = _serverDataAccessTests.SaveTestData();
        [Theory, MemberData(nameof(SaveTestData))]
        public void SaveTest(List<PartUpdate> partUpdates)
        {
            _serverDataAccessTests.SaveTest(partUpdates);
        }


        public static readonly object[][] SaveAndGetTestData = _serverDataAccessTests.SaveAndGetTestData();
        [Theory, MemberData(nameof(SaveAndGetTestData))]
        public void SaveAndGetTest(List<PartUpdate> partUpdates, List<Guid> getIds, List<PartUpdate> expected)
        {
            _serverDataAccessTests.SaveAndGetTest(partUpdates, getIds, expected);
        }


        public static readonly object[][] GetChangesTestData = _serverDataAccessTests.GetChangesTestData();
        [Theory, MemberData(nameof(GetChangesTestData))]
        public void GetChangesTest(List<PartUpdate> partUpdates, int lastSyncDateAdjustment, List<PartUpdate> expected)
        {
            _serverDataAccessTests.GetChangesTest(partUpdates, lastSyncDateAdjustment, expected);
        }


        public static readonly object[][] SaveConflictIdTestData = _serverDataAccessTests.SaveConflictIdTestData();
        [Theory, MemberData(nameof(SaveConflictIdTestData))]
        public void SaveConflictIdTest(List<PartUpdate> partUpdate, List<Conflict> conflicts, List<Conflict> expected)
        {
            _serverDataAccessTests.SaveConflictIdTest(partUpdate, conflicts, expected);
        }



        //TODO add in Delete Test when funcionality is setup
        //public static readonly object[][] DeleteTestData = _serverDataAccessTests.DeleteTestData();
        //[Theory,MemberData(nameof(DeleteTestData))]
        //public void DeleteTest(List<PartUpdate> partUpdatesToDelete)
        //{
        //   _serverDataAccessTests.DeleteTest(partUpdatesToDelete);
        //}



    }



}

