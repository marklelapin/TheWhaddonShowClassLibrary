﻿
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;

using System.Text;

using System.Net;
using MyClassLibrary.Extensions;
using System.Runtime.CompilerServices;

namespace TheWhaddonShowClassLibrary.DataAccess;

public class APIServerDataAccess : IServerDataAccess
{
    
    
    private IHttpClientFactory _httpClientFactory;

    public APIServerDataAccess(IHttpClientFactory httpClientFactory )
    {
        _httpClientFactory = httpClientFactory;
    }

    private string ControllerPrefix<T>()
    {
        string output;

        output = typeof(T).Name;

        if (!output.Contains("Update"))
        {
            throw new ArgumentException("The given LocalServerIdentityUpdate must follow the convention of class name in the form {type}Update.");
        }
        return output.Replace("Update", "");
    }




    public async Task  DeleteFromServer<T>(List<T> updates) where T : LocalServerIdentityUpdate
    {
        await Task.Run(() => throw new NotImplementedException());
    }

    public async Task<(List<T> changesFromServer, DateTime lastUpdatedOnServer)> GetChangesFromServer<T>(DateTime LastSyncDate) where T : LocalServerIdentityUpdate
    {
        
        DateTime outputLastUpdated;

        string requestUri = ControllerPrefix<T>() + $"/changes/{LastSyncDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff")}";
        
        (List<T>? outputChanges, HttpStatusCode statusCode) = await GetResult(requestUri).ConvertToAsync<List<T>>();

        outputLastUpdated = (outputChanges ?? new List<T>()).Max(x => x.UpdatedOnServer) ?? DateTime.MinValue;
        
        return (changesFromServer: outputChanges ?? new List<T>(),lastUpdatedOnServer: outputLastUpdated);
    }




    public async Task<List<T>> GetFromServer<T>(List<Guid>? ids) where T : LocalServerIdentityUpdate
    {
        string requestUri = ControllerPrefix<T>() + $"/{string.Join(",",ids)}";

        (List<T>? output, HttpStatusCode statusCode) = await GetResult(requestUri).ConvertToAsync<List<T>>();

        return output ?? new List<T>();
    }

    public async Task SaveConflictIdsToServer<T>(List<Conflict> conflicts) where T: LocalServerIdentityUpdate
    {
        string requestUri = ControllerPrefix<T>() +"/conflicts";
        string jsonObjects = JsonSerializer.Serialize(conflicts);

        await PostResult(requestUri, jsonObjects);
    }





    public async Task<DateTime> SaveToServer<T>(List<T> updates) where T : LocalServerIdentityUpdate
    {
        string requestUri = ControllerPrefix<T>()+"/updates";
        string jsonContent = JsonSerializer.Serialize(updates);

       var postTask = PostResult(requestUri, jsonContent);

        (DateTime updatedOnServer, HttpStatusCode statusCode) = await PostResult(requestUri,jsonContent).ConvertToAsync<DateTime>();

        AddUpdatedOnServer(updates, updatedOnServer);

        return updatedOnServer;


        //if (DateTime.TryParse(responseBody, out DateTime updatedOnServer))
        //{
        //    AddUpdatedOnServer(updates, updatedOnServer);
        //    return updatedOnServer;
        //}
        //else
        //{
        //    if (responseBody == "")
        //    {
        //        throw new Exception("No updatedOnServer date returned when running SaveToServer");
        //    } else
        //    {
        //        throw new Exception($"Output from API({requestUri}) cannot be converted to DateTime. Output=\"{responseBody}\"");
        //    }

        //}

    }

    private async Task<HttpResponseMessage> GetResult(string requestUri)
    {
        var client = CreateHttpClient();
        var getTask =  await  client.GetAsync(requestUri);
        return getTask;
    }

    private async Task<HttpResponseMessage> PostResult(string requestUri,string jsonContent)
    {
        var client = CreateHttpClient();   
        var postTask = await client.PostAsync(requestUri, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
        return postTask;
    }

    private HttpClient CreateHttpClient()
    {
      return _httpClientFactory.CreateClient("api");
    }

    private void AddUpdatedOnServer<T>(List<T> updates,DateTime updatedOnServer) where T : LocalServerIdentityUpdate
    {
        foreach (var update in updates) {
            update.UpdatedOnServer = updatedOnServer;
        };
    }
}