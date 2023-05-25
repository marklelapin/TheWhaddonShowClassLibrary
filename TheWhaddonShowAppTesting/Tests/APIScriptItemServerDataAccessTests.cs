﻿using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
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
    public class APIScriptItemServerDataAccessTests
    {
        
        
        private static IServiceConfiguration<ScriptItemUpdate> _serviceConfiguration = new APITestServiceConfiguration<ScriptItemUpdate>();
        
        private static IServerDataAccessTests<ScriptItemUpdate> _serverDataAccessTests = _serviceConfiguration.ServerDataAccessTests();
        

        public static object[][] SaveTestData = _serverDataAccessTests.SaveTestData();
        [Theory, MemberData(nameof(SaveTestData))]
        public void SaveTest(List<ScriptItemUpdate> scriptItemUpdates)
        {
            _serverDataAccessTests.SaveTest(scriptItemUpdates);
        }


        public static readonly object[][] SaveAndGetTestData = _serverDataAccessTests.SaveAndGetTestData();
        [Theory, MemberData(nameof(SaveAndGetTestData))]
        public void SaveAndGetTest(List<ScriptItemUpdate> scriptItemUpdates, List<Guid> getIds, List<ScriptItemUpdate> expected)
        {
            _serverDataAccessTests.SaveAndGetTest(scriptItemUpdates, getIds, expected);
        }


        public static readonly object[][] GetChangesTestData = _serverDataAccessTests.GetChangesTestData();
        [Theory, MemberData(nameof(GetChangesTestData))]
        public void GetChangesTest(List<ScriptItemUpdate> scriptItemUpdates, int lastSyncDateAdjustment, List<ScriptItemUpdate> expected)
        {
            _serverDataAccessTests.GetChangesTest(scriptItemUpdates, lastSyncDateAdjustment, expected);
        }


        public static readonly object[][] SaveConflictIdTestData = _serverDataAccessTests.SaveConflictIdTestData();
        [Theory, MemberData(nameof(SaveConflictIdTestData))]
        public void SaveConflictIdTest(List<ScriptItemUpdate> scriptItemUpdate, List<Conflict> conflicts, List<Conflict> expected)
        {
            _serverDataAccessTests.SaveConflictIdTest(scriptItemUpdate, conflicts, expected);
        }



        //TODO add in Delete Test when funcionality is setup
        //public static readonly object[][] DeleteTestData = _serverDataAccessTests.DeleteTestData();
        //[Theory,MemberData(nameof(DeleteTestData))]
        //public void DeleteTest(List<ScriptItemUpdate> scriptItemUpdatesToDelete)
        //{
        //   _serverDataAccessTests.DeleteTest(scriptItemUpdatesToDelete);
        //}



    }



}

