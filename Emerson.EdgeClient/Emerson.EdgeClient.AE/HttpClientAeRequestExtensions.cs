using System.Text;
using System.Threading;
using Emerson.EdgeClient.AE.Models;
using Emerson.EdgeClient.AE.Services;
using Newtonsoft.Json;

namespace Emerson.EdgeClient.AE
{
    public static class HttpClientAeRequestExtensions
    {
        private const string aeUrl = "api/v1/ae";

        /// <summary>
        /// Get Alarms and Events data using the default timespan and paging.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AeResponse> GetAeAsync(this HttpClient httpClient, CancellationToken token = default)
        {
            return await GetAsync<AeResponse>(httpClient, aeUrl);
        }

        /// <summary>
        /// Get Alarms and Events data using the default timespan and specified paging.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AeResponse> GetAeAsync(this HttpClient httpClient, int PageSize, int PageNumber, CancellationToken token = default)
        {
            var sb = new StringBuilder(aeUrl);
                sb.Append($"?PS={PageSize}");
                sb.Append($"&PN={PageNumber}");
            return await GetAsync<AeResponse>(httpClient, sb.ToString(), token);
        }

        /// <summary>
        /// Get Alarms and Events data via a custom timespan and default paging.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AeResponse> GetAeByTimespanAsync(this HttpClient httpClient, DateTime startTime, DateTime endTime, CancellationToken token = default)
        {
            //latest datetime should always be the start datetime... auto-correct if user got it reversed...
            var st = startTime > endTime ? startTime : endTime;
            var et = startTime > endTime ? endTime : startTime;

            //build request
            var sb = new StringBuilder(aeUrl);
                sb.Append($"?StartTime=\"{st}\"");
                sb.Append($"&EndTime=\"{et}\"");
            var param = sb.ToString();
            return await GetAsync<AeResponse>(httpClient, param, token);
        }
        
        /// <summary>
        /// Get Alarms and Events data via a custom Timespan range AND specified paging.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AeResponse> GetAeByTimespanAsync(this HttpClient httpClient, DateTime startTime, DateTime endTime, int pageSize, int pageNumber, CancellationToken token = default)
        {
            //latest datetime should always be the start datetime... auto-correct if user got it reversed...
            var st = startTime > endTime ? startTime : endTime;
            var et = startTime > endTime ? endTime : startTime;

            //build request
            var sb = new StringBuilder(aeUrl);
                sb.Append($"?StartTime=\"{st}\"");
                sb.Append($"&EndTime=\"{et}\"");
                sb.Append($"&PS={pageSize}");
                sb.Append($"&PN={pageNumber}");
            var param = sb.ToString();
            return await GetAsync<AeResponse>(httpClient, param, token);
        }


        /// <summary>
        /// Get Alarms and Events data using a user defined Alarms and Events property filter
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<AeResponse> GetAeWithFilterAsync(this HttpClient httpClient, AeFilterBuilder filter, CancellationToken token = default)
        {
            var filterString = filter.BuildFilter();
            return await GetAsync<AeResponse>(httpClient, aeUrl + filterString);
        }


        /// <summary>
        /// Helper function to send GetAsync request via HttpClient.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static async Task<T> GetAsync<T>(HttpClient client, string url, CancellationToken cancellationToken = default)
        {

            // Get data response
            var response = await client.GetAsync(url, cancellationToken);

            if (response == null || response?.Content == null || !response.IsSuccessStatusCode)
            {
                //return exception
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            // Parse the response body
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
