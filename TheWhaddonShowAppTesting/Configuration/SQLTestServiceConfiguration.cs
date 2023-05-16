using Microsoft.Extensions.Configuration;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.Tests.LocalServerMethods.Services;

namespace TheWhaddonShowTesting.Configuration
{


    public class SQLTestServiceConfiguration : IServiceConfiguration
    {

        public IConfiguration Config { get; set; }

        public SQLTestServiceConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddUserSecrets<SQLTestServiceConfiguration>();

            Config = builder.Build();
        }
        //TODO = Think the below can be combined with above through builder.addservices     
        public ILocalDataAccess LocalDataAccess() { return new LocalSQLConnector(new SqlDataAccess(Config)); }

        public IServerDataAccess ServerDataAccess() { return new ServerSQLConnector(new SqlDataAccess(Config)); }

        public ILocalDataAccessTests<T> LocalDataAccessTests<T>() where T : LocalServerIdentityUpdate { return new LocalDataAccessTestsService<T>(this); }

        public IServerDataAccessTests<T> ServerDataAccessTests<T>() where T : LocalServerIdentityUpdate { return new ServerDataAccessTestsService<T>(this); }

        public ITestContent<T> TestContent<T>() where T : LocalServerIdentityUpdate { return new TestContentService<T>(); }

        public ILocalServerEngine<T> LocalServerEngine<T>(ILocalDataAccess localDataAccess, IServerDataAccess serverDataAccess) where T : LocalServerIdentityUpdate
        {
            return new LocalServerEngine<T>(serverDataAccess, localDataAccess);
        }
    }
}

