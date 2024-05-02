using Emerson.EdgeClient.AE;
using Emerson.EdgeClient.Authentication;
using Emerson.EdgeClient.Authentication.Models;
using Emerson.EdgeClient.Graph;
using Emerson.EdgeClient.History;
using Newtonsoft.Json;
using System.Net.Http.Headers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Creating Authenticated HttpClient");

        var client = await CreateAuthenticatedHttpClient(); //see Authentication sample.
        var entityId = "123456";

        await GetGraph(client, entityId);
        await GetHistory(client, entityId);
        await GetAe(client);
    }

    private static async Task GetAe(HttpClient client)
    {
        await Console.Out.WriteLineAsync($"GetAeAsync STARTED");
        var ae = await client.GetAeAsync(30, 2);
        await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(ae));
        await Console.Out.WriteLineAsync($"GetAeAsync FINISHED");
    }

    private static async Task GetHistory(HttpClient client, string entityId)
    {
        await Console.Out.WriteLineAsync($"GetHistoryByIdAsync({entityId}) STARTED");
        var history = await client.GetHistoryByIdAsync(entityId, string.Empty);
        await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(history));
        await Console.Out.WriteLineAsync($"GetHistoryByIdAsync({entityId}) FINISHED");
        await Console.Out.WriteLineAsync(string.Empty);
    }

    public static async Task GetGraph(HttpClient client, string entityId)
    {
        await Console.Out.WriteLineAsync($"GetGraphByEntityIdAsync({entityId}) STARTED");
        var entity = await client.GetGraphByEntityIdAsync(entityId);
        await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(entity));
        await Console.Out.WriteLineAsync($"GetGraphByEntityIdAsync({entityId}) FINISHED");
        await Console.Out.WriteLineAsync(string.Empty);
    }

    public static async Task<HttpClient> CreateAuthenticatedHttpClient()
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, policyErrors) => { return true; };

        var client = new HttpClient(handler);

        var edgeUrl = "https://localhost/edge/"; //add your Edge REST API IP here
        var user = "user"; //add your REST API username here
        var pass = "pass"; //add your REST API password here

        client.BaseAddress = new Uri(edgeUrl);
        var token = await client.RequestClientTokenAsync(new Credentials
        {
            Username = user,
            Password = pass
        });

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

        return client;
    }
}