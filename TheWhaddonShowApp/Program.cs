using AspStudio.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApiMonitorClassLibrary.Interfaces;
using MyApiMonitorClassLibrary.Models;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;
using TheWhaddonShowClassLibrary.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Add Sidebar menu json file
builder.Configuration.AddJsonFile("sidebar.json", optional: true, reloadOnChange: true);


//Add services
builder.Services.AddTransient<ILocalServerModelUpdate, LocalServerModelUpdate>();
builder.Services.AddTransient(typeof(ILocalServerModel<>), typeof(LocalServerModel<>));
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped(typeof(ILocalDataAccess<>), typeof(LocalSQLConnector<>));
builder.Services.AddScoped(typeof(IServerDataAccess<>), typeof(APIServerDataAccess<>));
builder.Services.AddScoped(typeof(ILocalServerEngine<>), typeof(LocalServerEngine<>));
builder.Services.AddScoped(typeof(ILocalServerModelFactory<,>), typeof(LocalServerModelFactory<,>));

//Add services for api monitor
builder.Services.AddTransient<IMongoDBDataAccess>(sp => new MongoDBDataAccess(builder.Configuration.GetValue<string>("MongoDatabase:DatabaseName")!
                                                                                  , builder.Configuration.GetValue<string>("MongoDatabase:ConnectionString")!));
builder.Services.AddTransient<IApiTestDataAccess, ApiTestMongoDataAccess>();
builder.Services.AddTransient<IChartDataProcessor, ChartDataProcessor>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    //endpoints.MapAreaControllerRoute(
    //		name: "Identity",
    //		areaName: "Identity",
    //		pattern: "Identity/{controller=Home}/{action=Index}"); //TODO think I can get rid of this line of code from original template as dealt with below. 

    endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

    //endpoints.MapControllers();
    endpoints.MapDefaultControllerRoute();
});
#pragma warning restore ASP0014

app.MapRazorPages();

app.Run();
