using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;
using MyClassLibrary.Tests.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.Tests.LocalServerMethods.Services;
using MyClassLibrary.Tests.LocalServerMethods.Tests;
using TheWhaddonShowClassLibrary.Models;
using TheWhaddonShowTesting.Tests.Content;

namespace TheWhaddonShowTesting.Tests
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder) =>
          hostBuilder
          .ConfigureHostConfiguration(builder =>
          {

              builder.SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .AddUserSecrets<Startup>();
          });



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient(typeof(ILocalDataAccess<>), typeof(LocalSQLConnector<>));
            services.AddTransient(typeof(IServerDataAccess<>), typeof(ServerSQLConnector<>));
            services.AddTransient(typeof(ILocalServerEngine<>), typeof(LocalServerEngine<>));
            services.AddTransient(typeof(ISaveAndGetUpdateTypeTests<>), typeof(SaveAndGetUpdateTypeTestService<>));
            services.AddTransient<ISaveAndGetTestContent<PersonUpdate>, SaveAndGetPersonUpdateTestContent>();
            services.AddTransient<ISaveAndGetTestContent<PartUpdate>, SaveAndGetPartUpdateTestContent>();
            services.AddTransient<ISaveAndGetTestContent<ScriptItemUpdate>, SaveAndGetScriptItemUpdateTestContent>();

        }



    }
}


