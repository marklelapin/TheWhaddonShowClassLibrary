using Microsoft.Extensions.Configuration;
using MyClassLibrary.DataAccessMethods;
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities;

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




    public void DeleteFromServer<T>(List<T> updates) where T : LocalServerIdentityUpdate
    {
        throw new NotImplementedException();
    }

    public (List<T> changesFromServer, DateTime lastUpdatedOnServer) GetChangesFromServer<T>(DateTime LastSyncDate) where T : LocalServerIdentityUpdate
    {
        List<T> outputChanges = new List<T>();
        DateTime outputLastUpdated;

        string requestUri = ControllerPrefix<T>() + $"/changes/{LastSyncDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff")}";
        var stringResult = GetResult(requestUri);

        if (stringResult != "")        {
            outputChanges = JsonSerializer.Deserialize<List<T>>(stringResult) ?? new List<T>();
        }
              


        outputLastUpdated = (outputChanges ?? new List<T>()).Max(x => x.UpdatedOnServer) ?? DateTime.MinValue;
        
        return (changesFromServer: outputChanges,lastUpdatedOnServer: outputLastUpdated);
    }




    public List<T> GetFromServer<T>(List<Guid> ids) where T : LocalServerIdentityUpdate
    {
        List<T> output;
        string requestUri = ControllerPrefix<T>() + $"/{string.Join(",",ids)}";
        var stringResult = GetResult(requestUri);

        try
        {
            output = JsonSerializer.Deserialize<List<T>>(stringResult) ?? new List<T>();
        }
        catch
        {
           throw new Exception($"Output from API({requestUri}) cannot be converted to a list of type {typeof(T).Name}. Output = \"{stringResult}\"");
        }

        return output;

    }

    public void SaveConflictIdsToServer<T>(List<Conflict> conflicts) where T: LocalServerIdentityUpdate
    {
        string requestUri = ControllerPrefix<T>() +"/conflicts";
        string jsonObjects = JsonSerializer.Serialize(conflicts);

        PostResult(requestUri, jsonObjects);
    }





    public DateTime SaveToServer<T>(List<T> updates) where T : LocalServerIdentityUpdate
    {
        string requestUri = ControllerPrefix<T>()+"/updates";
        string jsonContent = JsonSerializer.Serialize(updates);

        var stringResult = PostResult(requestUri, jsonContent);

        if (DateTime.TryParse(stringResult, out DateTime updatedOnServer))
        {
            AddUpdatedOnServer(updates, updatedOnServer);
            return updatedOnServer;
        }
        else
        {
            if (stringResult == "")
            {
                throw new Exception("No updatedOnServer date returned.");
            } else
            {
                throw new Exception($"Output from API({requestUri}) cannot be converted to DateTime. Output=\"{stringResult}\"");
            }
           
        }

    }

    private string GetResult(string requestUri)
    {
        string result;
        var client = CreateHttpClient();
        Task<string> getTask = Task.Run(() => client.GetAsync(requestUri)).Result.Content.ReadAsStringAsync();
        getTask.Wait();
        result = getTask.Result;
        return result;
    }

    private string PostResult(string requestUri,string jsonContent)
    {
        string result;
        var client = CreateHttpClient();
        
        var postTask = Task.Run(() => client.PostAsync(requestUri, new StringContent(jsonContent, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync());
        postTask.Wait();
        string resultJson = postTask.Result ?? "";
        if (resultJson == "")
        {
            result = "";
        } else
        {
            result = JsonSerializer.Deserialize<string>(resultJson) ?? "";
        }
        
        return result;
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