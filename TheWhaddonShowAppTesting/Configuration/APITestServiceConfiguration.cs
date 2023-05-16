using Microsoft.Extensions.Configuration;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.Tests.LocalServerMethods.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Sdk;
using TheWhaddonShowClassLibrary.DataAccess;
using Microsoft.Extensions.Hosting;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowTesting.Configuration
{


    public class APITestServiceConfiguration : IServiceConfiguration
    {
        public IConfiguration Config { get; set; }
        private ServiceProvider _serviceProvider { get; set; }

        public APITestServiceConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddUserSecrets<APITestServiceConfiguration>();

            Config = builder.Build();

            var services = new ServiceCollection();

            services.AddHttpClient("api", options =>
            {
                options.BaseAddress = new Uri(Config.GetValue<string>("ApiUrl") ?? "Error");
            });

            _serviceProvider = services.BuildServiceProvider();

        }
        //TODO = Think the below can be combined with above through builder.addservices     
        public ILocalDataAccess LocalDataAccess() { return new LocalSQLConnector(new SqlDataAccess(Config)); }

        public IServerDataAccess ServerDataAccess() { return new APIServerDataAccess(_serviceProvider.GetService<IHttpClientFactory>()!); }

        public ILocalDataAccessTests<T> LocalDataAccessTests<T>() where T : LocalServerIdentityUpdate { return new LocalDataAccessTestsService<T>(this); }

        public IServerDataAccessTests<T> ServerDataAccessTests<T>() where T : LocalServerIdentityUpdate { return new ServerDataAccessTestsService<T>(this); }

        public ITestContent<T> TestContent<T>() where T : LocalServerIdentityUpdate { return new TestContentService<T>(); }

        public ILocalServerEngine<T> LocalServerEngine<T>(ILocalDataAccess localDataAccess, IServerDataAccess serverDataAccess) where T : LocalServerIdentityUpdate
        {
            return new LocalServerEngine<T>(serverDataAccess, localDataAccess);
        }
    }
}

