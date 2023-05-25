using Microsoft.Extensions.Configuration;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.Tests.LocalServerMethods.Services;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;

namespace TheWhaddonShowTesting.Configuration
{


    public class SQLTestServiceConfiguration<T> : IServiceConfiguration<T> where T: LocalServerModelUpdate,new()
    {

        public IConfiguration Config { get; set; }

        public SQLTestServiceConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddUserSecrets<SQLTestServiceConfiguration<T>>();

            Config = builder.Build();
        }
        //TODO = Think the below can be combined with above through builder.addservices     
        public ILocalDataAccess<T> LocalDataAccess() { return new LocalSQLConnector<T>(new SqlDataAccess(Config)); }

        public IServerDataAccess<T> ServerDataAccess() { return new ServerSQLConnector<T>(new SqlDataAccess(Config)); }

        public ILocalDataAccessTests<T> LocalDataAccessTests()  { return new LocalDataAccessTestsService<T>(this); }

        public IServerDataAccessTests<T> ServerDataAccessTests()  { return new ServerDataAccessTestsService<T>(this); }

        public ITestContent<T> TestContent() { return new TestContentService<T>(); }

        public ILocalServerEngine<T> LocalServerEngine(ILocalDataAccess<T> localDataAccess, IServerDataAccess<T> serverDataAccess)
        {
            return new LocalServerEngine<T>(serverDataAccess, localDataAccess);
        }
    }
}

