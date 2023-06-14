using Microsoft.Identity.Web.UI;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.Extensions;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;




var builder = WebApplication.CreateBuilder(args);

builder.ConfigureWebAuthentication_AzureAdB2C();

builder.RequireAuthorizationThroughoutAsFallbackPolicy();

//builder.ByPassAuthenticationIfInDevelopment();   

// Add Razor Pages and authorize access
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AllowAnonymousToPage("/Index");
    options.Conventions.AllowAnonymousToPage("/Privacy");
    options.Conventions.AllowAnonymousToFolder("/Script");

});



//Add services
builder.Services.AddTransient<ILocalServerModelUpdate, LocalServerModelUpdate>();
builder.Services.AddTransient(typeof(ILocalServerModel<>),typeof(LocalServerModel<>));
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped(typeof(ILocalDataAccess<>),typeof(LocalSQLConnector<>));
builder.Services.AddSingleton(typeof(IServerDataAccess<>),typeof(ServerSQLConnector<>));
builder.Services.AddScoped(typeof(ILocalServerEngine<>), typeof(LocalServerEngine<>));
builder.Services.AddScoped(typeof(ILocalServerModelFactory<,>), typeof(LocalServerModelFactory<,>));


var app = builder.Build();


//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithRedirects("/Error/{0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapRazorPages();
app.MapControllers();

app.Run();
