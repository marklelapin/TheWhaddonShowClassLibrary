using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods;
using System.Reflection;
using System.Text;
using TheWhaddonShowClassLibrary.Models;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authorization;
using MyClassLibrary.Configuration;
using MyClassLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);



//TODO Tidy Up Program.cs and check Appsettings etc.
//TODO Add in HealthChecks and Logging
//TODO Get Version 1 working
//TODO ROCP Access to API for Integration Testing

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
                                    {
                                        builder.Configuration.Bind("AzureAdB2C", options);

                                        options.TokenValidationParameters.NameClaimType = "name";
                                    },
                                   options =>
                                   {
                                       builder.Configuration.Bind("AzureAdB2C", options);
                                   });



builder.ByPassAuthenticationIfInDevelopment();






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    var title = "The Whaddon Show API";
    var description = "Provides data access to The Whaddon Show's central database.";
    var contact = new OpenApiContact()
    {
        Name = "Mark Carter",
        Email = "magcarter@hotmail.co.uk"
        //TODO - add in home page to OpenApiContact
    };

    opts.SwaggerDoc("v1 (deprecated)", new OpenApiInfo()
    {
        Version = "v1",
        Title = title,
        Description = description,
        Contact = contact
    });
    opts.SwaggerDoc("v2", new OpenApiInfo()
    {
        Version = "v2",
        Title = title,
        Description = description,
        Contact = contact
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});
builder.Services.AddApiVersioning(opts =>
{
    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.DefaultApiVersion = new(2, 0);
    opts.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(opts =>
{
    opts.GroupNameFormat = "'v'VVV";
    opts.SubstituteApiVersionInUrl = true;
});


builder.Services.AddHealthChecks();


builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IServerDataAccess>(provider => new ServerSQLConnector(provider.GetService<ISqlDataAccess>()!));











var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opts.RoutePrefix = string.Empty;
        
    });
//}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); ;
app.MapHealthChecks("/health"); 
app.Run();
