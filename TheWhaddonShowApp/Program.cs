using AspStudio.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;

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
app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
			name: "Identity",
			areaName: "Identity",
			pattern: "Identity/{controller=Home}/{action=Index}");
	endpoints.MapControllers();
});
app.MapRazorPages();

app.Run();
