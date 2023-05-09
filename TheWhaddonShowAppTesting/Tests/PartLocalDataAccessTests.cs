using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowTesting.Configuration;

namespace TheWhaddonShowTesting.Tests
{
    public class PartLocalDataAccessTests
    {
        private static IServiceConfiguration _serviceConfiguration = new WhaddonShow_TestServiceConfiguration();

        private static ILocalDataAccessTests<PartUpdate> _localDataAccessTests = new LocalDataAccessTestsService<PartUpdate>(_serviceConfiguration);

        //private static ITestContent<PartUpdate> _testContent = new TestContentService<TestUpdate>();

        public static object[][] SaveTestData = _localDataAccessTests.SaveTestData();
        [Theory, MemberData(nameof(SaveTestData))]
        public void SaveTest(List<PartUpdate> partUpdates)
        {
            _localDataAccessTests.SaveTest(partUpdates);
        }

        public static object[][] SaveAndGetTestData = _localDataAccessTests.SaveAndGetTestData();
        [Theory, MemberData(nameof(SaveAndGetTestData))]
        public void SaveAndGetTest(List<PartUpdate> partUpdates, List<Guid> idsToGet, List<PartUpdate> expected)
        {
            _localDataAccessTests.SaveAndGetTest(partUpdates, idsToGet, expected);
        }

        public static object[][] GetChangesTestData = _localDataAccessTests.GetChangesTestData();
        [Theory, MemberData(nameof(GetChangesTestData))]
        public void GetChangesTest(List<PartUpdate> partUpdates)
        {
            _localDataAccessTests.GetChangesTest(partUpdates);
        }


        public static object[][] SaveAndGetLocalLastSyncDateTestData = _localDataAccessTests.SaveAndGetLocalLastSyncDateTestData();
        [Theory, MemberData(nameof(SaveAndGetLocalLastSyncDateTestData))]
        public void SaveAndGetLocalLastSyncDateTest(DateTime expected)
        {
            _localDataAccessTests.SaveAndGetLocalLastSyncDateTest(expected);
        }


        public static object[][] SaveUpdatedOnServerTestData = _localDataAccessTests.SaveUpdatedOnServerTestData();
        [Theory, MemberData(nameof(SaveUpdatedOnServerTestData))]
        public void SaveUpdatedOnServerTest(List<PartUpdate> partUpdates)
        {
            _localDataAccessTests.SaveUpdatedOnServerTest(partUpdates);
        }


        public static object[][] SaveConflictIdTestData = _localDataAccessTests.SaveConflictIdTestData();
        [Theory, MemberData(nameof(SaveConflictIdTestData))]
        public void SaveConflictIdTest(List<PartUpdate> partUpdates, List<Conflict> conflicts, List<Conflict> expected)
        {
            _localDataAccessTests.SaveConflictIdTest(partUpdates, conflicts, expected);
        }

        //TODO Add in PArtUpdate Delete Test when functionality added
        //public static object[][] DeleteTestData = _localDataAccessTests.DeleteTestData();
        //[Theory, MemberData(nameof(DeleteTestData))]
        //public void DeleteTest(List<PartUpdate> partUpdatesToDelete)
        //{
        //    _localDataAccessTests.DeleteTest(partUpdatesToDelete);
        //}
    }
}
