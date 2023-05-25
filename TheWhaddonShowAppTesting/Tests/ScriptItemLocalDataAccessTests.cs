
using MyClassLibrary.LocalServerMethods.Models;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Services;

using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowTesting.Tests
{
    public class ScriptItemLocalDataAccessTests
    {
        private static IServiceConfiguration<ScriptItemUpdate> _serviceConfiguration = new Configuration.SQLTestServiceConfiguration<ScriptItemUpdate>();

        private static ILocalDataAccessTests<ScriptItemUpdate> _localDataAccessTests = new LocalDataAccessTestsService<ScriptItemUpdate>(_serviceConfiguration);

        //private static ITestContent<ScriptItemUpdate> _testContent = new TestContentService<TestUpdate>();

        public static object[][] SaveTestData = _localDataAccessTests.SaveTestData();
        [Theory, MemberData(nameof(SaveTestData))]
        public void SaveTest(List<ScriptItemUpdate> scriptItemUpdates)
        {
            _localDataAccessTests.SaveTest(scriptItemUpdates);
        }

        public static object[][] SaveAndGetTestData = _localDataAccessTests.SaveAndGetTestData();
        [Theory, MemberData(nameof(SaveAndGetTestData))]
        public void SaveAndGetTest(List<ScriptItemUpdate> scriptItemUpdates, List<Guid> idsToGet, List<ScriptItemUpdate> expected)
        {
            _localDataAccessTests.SaveAndGetTest(scriptItemUpdates, idsToGet, expected);
        }

        public static object[][] GetChangesTestData = _localDataAccessTests.GetChangesTestData();
        [Theory, MemberData(nameof(GetChangesTestData))]
        public void GetChangesTest(List<ScriptItemUpdate> scriptItemUpdates)
        {
            _localDataAccessTests.GetChangesTest(scriptItemUpdates);
        }


        public static object[][] SaveAndGetLocalLastSyncDateTestData = _localDataAccessTests.SaveAndGetLocalLastSyncDateTestData();
        [Theory, MemberData(nameof(SaveAndGetLocalLastSyncDateTestData))]
        public void SaveAndGetLocalLastSyncDateTest(DateTime expected)
        {
            _localDataAccessTests.SaveAndGetLocalLastSyncDateTest(expected);
        }


        public static object[][] SaveUpdatedOnServerTestData = _localDataAccessTests.SaveUpdatedOnServerTestData();
        [Theory, MemberData(nameof(SaveUpdatedOnServerTestData))]
        public void SaveUpdatedOnServerTest(List<ScriptItemUpdate> scriptItemUpdates)
        {
            _localDataAccessTests.SaveUpdatedOnServerTest(scriptItemUpdates);
        }


        public static object[][] SaveConflictIdTestData = _localDataAccessTests.SaveConflictIdTestData();
        [Theory, MemberData(nameof(SaveConflictIdTestData))]
        public void SaveConflictIdTest(List<ScriptItemUpdate> scriptItemUpdates, List<Conflict> conflicts, List<Conflict> expected)
        {
            _localDataAccessTests.SaveConflictIdTest(scriptItemUpdates, conflicts, expected);
        }

        //TODO Add in PArtUpdate Delete Test when functionality added
        //public static object[][] DeleteTestData = _localDataAccessTests.DeleteTestData();
        //[Theory, MemberData(nameof(DeleteTestData))]
        //public void DeleteTest(List<ScriptItemUpdate> scriptItemUpdatesToDelete)
        //{
        //    _localDataAccessTests.DeleteTest(scriptItemUpdatesToDelete);
        //}
    }
}
