using Microsoft.Extensions.Configuration;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.Tests.LocalServerMethods.Services;
using Microsoft.Extensions.DependencyInjection;
using TheWhaddonShowClassLibrary.DataAccess;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;

namespace TheWhaddonShowTesting.Configuration
{

    public class APITestServiceConfiguration<T> : IServiceConfiguration<T> where T : LocalServerModelUpdate, new()
    {
        public IConfiguration Config { get; set; }
        private ServiceProvider _serviceProvider { get; set; }

        public APITestServiceConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddUserSecrets<APITestServiceConfiguration<T>>();

            Config = builder.Build();


            var PublicClientApplicationOptions = new PublicClientApplicationOptions();
            Config.Bind("Authentication", PublicClientApplicationOptions);
            var app = PublicClientApplicationBuilder.CreateWithApplicationOptions(PublicClientApplicationOptions)
                .Build();

            string[] scopes = Config.GetSection("WebAPI:Scopes").Get<string[]>()!;
            string username = Config.GetValue<string>("TestUser:Username")!;
            string password = Config.GetValue<string>("TestUser:Password")!;
            

           
            string accessToken;
            try
            {
                Task<AuthenticationResult> getToken =  app.AcquireTokenByUsernamePassword(scopes, username, password).ExecuteAsync();
                getToken.Wait();
                accessToken = getToken.Result.AccessToken;
            }
            catch (MsalException ex) {

                throw new Exception("Failed to get Access Token through ROPC", ex);
            }


            var services = new ServiceCollection();
            services.AddHttpClient("api", options =>
            {
                options.BaseAddress = new Uri(Config.GetValue<string>("ApiUrl")!);
                options.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            }
            );

            _serviceProvider = services.BuildServiceProvider();
            
        }
        //TODO = Think the below can be combined with above through builder.addservices     
        public ILocalDataAccess<T> LocalDataAccess() { return new LocalSQLConnector<T>(new SqlDataAccess(Config)); }

        public IServerDataAccess<T> ServerDataAccess() { return new APIServerDataAccess<T>(_serviceProvider.GetService<IHttpClientFactory>()!); }

        public ILocalDataAccessTests<T> LocalDataAccessTests()  { return new LocalDataAccessTestsService<T>(this); }

        public IServerDataAccessTests<T> ServerDataAccessTests()  { return new ServerDataAccessTestsService<T>(this); }

        public ITestContent<T> TestContent()  { return new TestContentService<T>(); }

        public ILocalServerEngine<T> LocalServerEngine(ILocalDataAccess<T> localDataAccess, IServerDataAccess<T> serverDataAccess)
        {
            return new LocalServerEngine<T>(serverDataAccess, localDataAccess);
        }
    }
}

