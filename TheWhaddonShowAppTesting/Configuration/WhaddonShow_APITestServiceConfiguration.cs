using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowTesting;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.Tests.LocalServerMethods.Services;

namespace TheWhaddonShowTesting.Configuration
{


    public class WhaddonShow_APITestServiceConfiguration : IServiceConfiguration
    {

        public IConfiguration Config { get; private set; }

        public WhaddonShow_APITestServiceConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            Config = builder.Build();
        }
        //TODO = Think the below can be combined with above through builder.addservices     
        public ILocalDataAccess LocalDataAccess() { return new LocalSQLConnector(new SqlDataAccess(Config)); }

        public IServerDataAccess ServerDataAccess() { return new ServerSQLConnector(new SqlDataAccess(Config)); }

        public ILocalDataAccessTests<T> LocalDataAccessTests<T>() where T : LocalServerIdentityUpdate { return new LocalDataAccessTestsService<T>(this); }

        public IServerDataAccessTests<T> ServerDataAccessTests<T>() where T : LocalServerIdentityUpdate { return new ServerDataAccessTestsService<T>(this); }

        public ITestContent<T> TestContent<T>() where T : LocalServerIdentityUpdate { return new WhaddonShow_TestContentService<T>(); }

        public ILocalServerEngine<T> LocalServerEngine<T>(ILocalDataAccess localDataAccess, IServerDataAccess serverDataAccess) where T : LocalServerIdentityUpdate
        {
            return new LocalServerEngine<T>(serverDataAccess, localDataAccess);
        }
    }
}

