
using MyClassLibrary.LocalServerMethods;
using System.Text.Json;

using System.Text;

using System.Net;
using MyClassLibrary.Extensions;
using System.Runtime.CompilerServices;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;
using Microsoft.Identity.Abstractions;
using Microsoft.Extensions.Options;
using System.Security.Authentication.ExtendedProtection;

namespace TheWhaddonShowClassLibrary.DataAccess;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// Requires a downstreamApi with a serviceName of "TheWhaddonShowApi" to have been configure in program.cs 
/// </remarks>
/// <typeparam name="T"></typeparam>
public class APIServerDataAccess<T> : IServerDataAccess<T> where T : LocalServerModelUpdate
{
    //TODO Test APIServerDataAccess with Authentication

    private IDownstreamApi _downstreamApi;

    private string ServiceName { get; set; } = "TheWhaddonShowApi";

    public APIServerDataAccess(IDownstreamApi downstreamApi)
    {
        _downstreamApi = downstreamApi;
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

        string idsString = ConvertIdsListGuidToString(ids);

        string requestUri;
        if (latestOnly)
        {
            requestUri = ControllerPrefix() + $"/latest/?ids={idsString}";
        }
        else
        {
            requestUri = ControllerPrefix() + $"/history/?ids={idsString}";
        }

        (List<T>? output, HttpStatusCode statusCode) = await GetResult(requestUri).ConvertToAsync<List<T>>();

        return output ?? new List<T>();
    }


    public async Task<List<T>> GetConflictedUpdatesFromServer(List<Guid>? ids)
    {
        string idsString = ConvertIdsListGuidToString(ids);

        string requestUri = ControllerPrefix() + $"/conflicts/?ids={idsString}";

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
        string requestUri = ControllerPrefix() + $"/conflicts/clear/{ConvertIdsListGuidToString(ids)}";
        string jsonContent = "";

        await PutResult(requestUri, jsonContent);
    }


    public async Task<bool> ResetSampleData(List<T> updates,List<ServerSyncLog> serverSyncLogs)
    {
        return await ResetSampleData(); //TODO ResetSampleData doesn't 100% fullfill interface here. Does this need changing?
    }

    public async Task<bool> ResetSampleData()
    {
        string requestUri = ControllerPrefix() + "/resetsampledata";

        await DeleteResult(requestUri);

        return true;
    }


    public Task DeleteFromServer(List<T> updates)
    {
        throw new NotImplementedException(); //TODO add delete from server functionality
    }


    //Helper Methods

    private async Task<HttpResponseMessage> GetResult(string requestUri)
    {

        var getTask = await _downstreamApi.CallApiForAppAsync(ServiceName, options =>
        {
            options.HttpMethod = HttpMethod.Get;
            options.RelativePath = requestUri;
        });

        return getTask;
    }

    private async Task<HttpResponseMessage> PostResult(string requestUri, string jsonContent)
    {
        var postTask = await _downstreamApi.CallApiForAppAsync(ServiceName
                                                               , options =>
                                                                {
                                                                    options.HttpMethod = HttpMethod.Post;
                                                                    options.RelativePath = requestUri;
                                                                }
                                                                , new StringContent(jsonContent, Encoding.UTF8, "application/json")
                                                                );
        return postTask;
    }

    private async Task<HttpResponseMessage> PutResult(string requestUri, string jsonContent)
    {
        var putTask = await _downstreamApi.CallApiForAppAsync(ServiceName
            , options =>
            {
                options.HttpMethod = HttpMethod.Put;
                options.RelativePath = requestUri;
            }
            , new StringContent(jsonContent, Encoding.UTF8, "application/json")
            );
            
        return putTask;
    }


    private async Task<HttpResponseMessage> DeleteResult(string requestUri)
    {
        var deleteTask = await _downstreamApi.CallApiForUserAsync(ServiceName
            , options =>
            {
                options.HttpMethod = HttpMethod.Delete;
                options.RelativePath = requestUri;
            }
            );

        return deleteTask;
    }

     

    private string ConvertIdsListGuidToString(List<Guid>? ids)
    {
        string output;

        if (ids == null)
        {
            output = "all";
        } else
        {
            output = string.Join(",", ids);
        }

        return output;
    }

 
}
