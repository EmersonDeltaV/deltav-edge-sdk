using Emerson.EdgeClient.Graph.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Emerson.EdgeClient.Graph
{
    public static class HttpClientGraphExtension
    {
        private const string RequestURI = "api/v1/graph";


        public static async Task<Entity> GetGraphByEntityIdAsync(this HttpClient client, string entityId, List<string>? properties = null, List<string>? relationships = null)
        {
            return await GetGraphByEntityIdResponseAsync<Entity>(client, entityId, properties, relationships);
        }

        public static async Task<Entity> GetGraphByPathAsync(this HttpClient client, string entityId, List<string>? properties = null, List<string>? relationships = null)
        {
            return await GetGraphByPathResponseAsync<Entity>(client, entityId, properties, relationships);
        }

        private static async Task<Entity> GetGraphByEntityIdResponseAsync<T>(this HttpClient client, string entityId, List<string>? properties = null, List<string>? relationships = null)
        {
            string propertiesParam = ConvertListToCommaSeparatedString(properties);
            string relationshipsParam = ConvertListToCommaSeparatedString(relationships);

            string requestURL = $"{RequestURI}/{entityId}?p={propertiesParam}&r={relationshipsParam}";

            var response = await GetResponse(client, requestURL);
            return response;
        }

        private static async Task<Entity> GetGraphByPathResponseAsync<T>(this HttpClient client, string path, List<string>? properties = null, List<string>? relationships = null)
        {
            string propertiesParam = ConvertListToCommaSeparatedString(properties);
            string relationshipsParam = ConvertListToCommaSeparatedString(relationships);

            string requestURL = $"{RequestURI}?path={path}&p={propertiesParam}&r={relationshipsParam}";

            var response = await GetResponse(client, requestURL);
            return response;
        }

        private static string ConvertListToCommaSeparatedString(List<string> items)
        {
            return items != null ? $"{string.Join(",", items)}" : "1";
        }

        private static async Task<Entity> GetResponse(HttpClient client, string requestURL, CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(requestURL, cancellationToken);
 
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Entity>(result);
        }
    }
}
