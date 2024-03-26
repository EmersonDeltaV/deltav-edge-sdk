using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using Emerson.EdgeClient.History.Models;

namespace Emerson.EdgeClient.History
{
    public static class HttpClientHistoryExtension
    {

        private const string HistoryUrl = "api/v1/history";

        public static async Task<Models.History> GetHistoryByIdAsync(this HttpClient client, string entityID, string field)
        {
            string requestURL = $"{HistoryUrl}/{entityID}?p={field}";

            var response = await GetResponseAsync(client, requestURL);
                       
            return response;

        }

        public static async Task<Models.History> GetHistoryByPathAsync(this HttpClient client, string path, string field)
        {
            string requestURL = $"{HistoryUrl}?path={path}&p={field}";

            var response = await GetResponseAsync(client, requestURL);

            return response;

        }

        public static async Task<Models.History> GetHistoryByPathAsync(this HttpClient client, string path, List<string> field)
        {
            string parameter = "";
            string last = field.Last();
            foreach ( var item in field )
            {
                if (last.Equals(item))
                {
                    parameter = parameter + item;
                }
                else
                {
                    parameter = parameter + item + ",";
                }
            }
            string requestURL = $"{HistoryUrl}?path={path}&p={parameter}";

            var response = await GetResponseAsync(client, requestURL);

            return response;
        }

        private static async Task<Models.History> GetResponseAsync(HttpClient client, string requestURL, CancellationToken cancellationToken = default)
        {

            try
            {
                var response = await client.GetAsync(requestURL, cancellationToken);
                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new Exception($"Error 404: {requestURL}");

                var result = await response.Content.ReadAsStringAsync();

                var History = JsonConvert.DeserializeObject<Models.History>(result);
                return History;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {requestURL} message : {ex.Message}");

            }


        }

    }

}
