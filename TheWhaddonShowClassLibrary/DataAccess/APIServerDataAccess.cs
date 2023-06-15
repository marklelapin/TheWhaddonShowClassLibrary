
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;

using System.Text;

using System.Net;
using MyClassLibrary.Extensions;
using System.Runtime.CompilerServices;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;

namespace TheWhaddonShowClassLibrary.DataAccess;

public class APIServerDataAccess<T> : IServerDataAccess<T> where T : LocalServerModelUpdate
{
    //TODO Test APIServerDataAccess with Authentication

    private IHttpClientFactory _httpClientFactory;

    public APIServerDataAccess(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private string ControllerPrefix()
    {
        string output;

        output = typeof(T).Name;

        if (!output.Contains("Update"))
        {
            throw new ArgumentException("The given LocalServerIdentityUpdate must follow the convention of class name in the form {type}Update.");
        }
        return output.Replace("Update", "");
    }


    public async Task<List<T>> GetUpdatesFromServer(List<Guid>? ids, bool latestOnly)
    {
        string requestUri;
        if (latestOnly)
        {
            requestUri = ControllerPrefix() + $"/latest/{string.Join(",", ids)}";
        }
        else
        {
            requestUri = ControllerPrefix() + $"/history/{string.Join(",", ids)}";
        }

        (List<T>? output, HttpStatusCode statusCode) = await GetResult(requestUri).ConvertToAsync<List<T>>();

        return output ?? new List<T>();
    }


    public async Task<List<T>> GetConflictedUpdatesFromServer(List<Guid>? ids)
    {
        string requestUri = ControllerPrefix() + $"/conflicts/{string.Join(",", ids)}";

        (List<T>? output, HttpStatusCode statusCode) = await GetResult(requestUri).ConvertToAsync<List<T>>();

        return output ?? new List<T>();
    }


    public async Task<List<T>> GetUnsyncedFromServer(Guid localCopyId)
    {
         string requestUri = ControllerPrefix() + $"/unsynced/{localCopyId.ToString()}";

        (List<T>? output, HttpStatusCode statusCode) = await GetResult(requestUri).ConvertToAsync<List<T>>();

        return output ?? new List<T>();
    }



    public async Task<List<ServerToLocalPostBack>> SaveUpdatesToServer(List<T> updates, Guid localCopyId)
    {
        string requestUri = ControllerPrefix() + $"/updates/{localCopyId.ToString()}";

        string jsonContent = JsonSerializer.Serialize(updates);

        (List<ServerToLocalPostBack>? postBack, HttpStatusCode statusCode) = await PostResult(requestUri, jsonContent).ConvertToAsync<List<ServerToLocalPostBack>>();

        return postBack ?? new List<ServerToLocalPostBack>();

    }


    public async Task LocalPostBackToServer(List<LocalToServerPostBack> postBacks, Guid localCopyId)
    {
        string requestUri = ControllerPrefix() + $"/updates/postbackfromlocal/{localCopyId}";

        string jsonContent = JsonSerializer.Serialize(postBacks);

        await PostResult(requestUri, jsonContent).ConvertToAsync<string>();

    }


    public async Task ClearConflictsFromServer(List<Guid> ids)
    {
        string requestUri = ControllerPrefix() + $"/conflicts/clear/{string.Join(",", ids)}";
        string jsonContent = "";

        await PostResult(requestUri, jsonContent);
    }




    public Task<bool> ResetSampleData(string folderPath)
    {
        throw new NotImplementedException();
    }


    public async Task DeleteFromServer(List<T> updates)
    {
        await Task.Run(() => throw new NotImplementedException());
    }





    //Helper Methods

    private async Task<HttpResponseMessage> GetResult(string requestUri)
    {
        var client = CreateHttpClient();
        var getTask = await client.GetAsync(requestUri);
        return getTask;
    }

    private async Task<HttpResponseMessage> PostResult(string requestUri, string jsonContent)
    {
        var client = CreateHttpClient();
        var postTask = await client.PostAsync(requestUri, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
        return postTask;
    }

    private HttpClient CreateHttpClient()
    {
        return _httpClientFactory.CreateClient("api");
    }

    private void AddUpdatedOnServer<T>(List<T> updates, DateTime updatedOnServer) where T : LocalServerModelUpdate
    {
        foreach (var update in updates)
        {
            update.UpdatedOnServer = updatedOnServer;
        };
    }

    public Task<bool> ResetSampleData(List<T> sampleUpdates, List<ServerSyncLog> sampleServerSyncLogs)
    {
        throw new NotImplementedException();
    }
}
