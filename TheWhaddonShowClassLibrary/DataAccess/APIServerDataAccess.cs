
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;

using System.Text;

using System.Net;
using MyClassLibrary.Extensions;

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
        
        DateTime outputLastUpdated;

        string requestUri = ControllerPrefix<T>() + $"/changes/{LastSyncDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff")}";
        
        (List<T>? outputChanges, HttpStatusCode statusCode) = GetResult(requestUri).ConvertTo<List<T>>();

        outputLastUpdated = (outputChanges ?? new List<T>()).Max(x => x.UpdatedOnServer) ?? DateTime.MinValue;
        
        return (changesFromServer: outputChanges ?? new List<T>(),lastUpdatedOnServer: outputLastUpdated);
    }




    public List<T> GetFromServer<T>(List<Guid>? ids) where T : LocalServerIdentityUpdate
    {
        string requestUri = ControllerPrefix<T>() + $"/{string.Join(",",ids)}";

        (List<T>? output, HttpStatusCode statusCode) = GetResult(requestUri).ConvertTo<List<T>>();

        return output ?? new List<T>();
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

       (DateTime updatedOnServer,HttpStatusCode statusCode) = PostResult(requestUri, jsonContent).ConvertTo<DateTime>();

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

    private Task<HttpResponseMessage> GetResult(string requestUri)
    {
        var client = CreateHttpClient();
        Task<HttpResponseMessage> getTask = Task.Run(() => client.GetAsync(requestUri).Result);
        return getTask;
    }

    private Task<HttpResponseMessage> PostResult(string requestUri,string jsonContent)
    {
        var client = CreateHttpClient();   
        Task<HttpResponseMessage> postTask = Task.Run(() => client.PostAsync(requestUri, new StringContent(jsonContent, Encoding.UTF8, "application/json")));
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