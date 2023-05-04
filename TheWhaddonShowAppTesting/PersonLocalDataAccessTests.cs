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

namespace TheWhaddonShowTesting
{
    public class PersonLocalDataAccessTests
    {
        private static IServiceConfiguration _serviceConfiguration = new WhaddonShow_TestServiceConfiguration();

        private static ILocalDataAccessTests<PersonUpdate> _localDataAccessTests = new LocalDataAccessTestsService<PersonUpdate>(_serviceConfiguration);

        public static object[][] SaveTestData = _localDataAccessTests.SaveTestData();
        [Theory, MemberData(nameof(SaveTestData))]
        public void SaveTest(List<PersonUpdate> personUpdates)
        {
            _localDataAccessTests.SaveTest(personUpdates);
        }

        public static object[][] SaveAndGetTestData = _localDataAccessTests.SaveAndGetTestData();
        [Theory, MemberData(nameof(SaveAndGetTestData))]
        public void SaveAndGetTest(List<PersonUpdate> personUpdates, List<Guid> idsToGet, List<PersonUpdate> expected)
        {
            _localDataAccessTests.SaveAndGetTest(personUpdates, idsToGet, expected);
        }

        public static object[][] GetChangesTestData = _localDataAccessTests.GetChangesTestData();
        [Theory, MemberData(nameof(GetChangesTestData))]
        public void GetChangesTest(List<PersonUpdate> personUpdates)
        {
            _localDataAccessTests.GetChangesTest(personUpdates);
        }


        public static object[][] SaveAndGetLocalLastSyncDateTestData = _localDataAccessTests.SaveAndGetLocalLastSyncDateTestData();
        [Theory, MemberData(nameof(SaveAndGetLocalLastSyncDateTestData))]
        public void SaveAndGetLocalLastSyncDateTest(DateTime expected)
        {
            _localDataAccessTests.SaveAndGetLocalLastSyncDateTest(expected);
        }


        public static object[][] SaveUpdatedOnServerTestData = _localDataAccessTests.SaveUpdatedOnServerTestData();
        [Theory, MemberData(nameof(SaveUpdatedOnServerTestData))]
        public void SaveUpdatedOnServerTest(List<PersonUpdate> personUpdates)
        {
            _localDataAccessTests.SaveUpdatedOnServerTest(personUpdates);
        }


        public static object[][] SaveConflictIdTestData = _localDataAccessTests.SaveConflictIdTestData();
        [Theory, MemberData(nameof(SaveConflictIdTestData))]
        public void SaveConflictIdTest(List<PersonUpdate> personUpdates, List<Conflict> conflicts, List<Conflict> expected)
        {
            _localDataAccessTests.SaveConflictIdTest(personUpdates, conflicts, expected);
        }

        //TODO Add in PArtUpdate Delete Test when functionality added
        //public static object[][] DeleteTestData = _localDataAccessTests.DeleteTestData();
        //[Theory, MemberData(nameof(DeleteTestData))]
        //public void DeleteTest(List<PersonUpdate> personUpdatesToDelete)
        //{
        //    _localDataAccessTests.DeleteTest(personUpdatesToDelete);
        //}
    }
}
