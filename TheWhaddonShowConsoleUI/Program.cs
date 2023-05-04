

using Microsoft.Extensions.Configuration;
using TheWhaddonShowClassLibrary.Models;

Console.WriteLine(GetConnectionString());


static string GetConnectionString(string connectionStringName="Default")
{
    string output;
    
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()) .AddJsonFile("appsettings.json");

    var config = builder.Build();

    output = config.GetConnectionString(connectionStringName) ?? String.Empty;

    return output;
}






