using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.Extensions;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;
using TheWhaddonShowClassLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAuthentication_AzureAdB2C();

builder.ByPassAuthenticationIfInDevelopment();

// Add services to the container.
builder.Services.AddRazorPages();  //Do I need to add something more her for Azure AdB2C

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped(typeof(ILocalDataAccess<>),typeof(LocalSQLConnector<>));
builder.Services.AddSingleton(typeof(IServerDataAccess<>),typeof(ServerSQLConnector<>));
builder.Services.AddSingleton(typeof(ILocalServerEngine<>), typeof(LocalServerEngine<>));
builder.Services.AddSingleton(typeof(ILocalServerModel<>), typeof(LocalServerModel<>));
builder.Services.AddSingleton(typeof(ILocalServerModelFactory<,>), typeof(LocalServerModelFactory<,>));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
