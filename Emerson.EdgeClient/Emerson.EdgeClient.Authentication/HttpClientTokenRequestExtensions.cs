using Emerson.EdgeClient.Authentication.Models;
using Newtonsoft.Json;
using System.Net;

namespace Emerson.EdgeClient.Authentication
{
    public static class HttpClientTokenRequestExtensions
    {
        private const string authUrl = "api/v1/Login/GetAuthToken/profile";

        /// <summary>
        /// Sends a token request
        /// </summary>
        /// <param name="client">The HttpClient.</param>
        /// <param name="credentials">The credentials containing Username and Password.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task<TokenResponse> RequestClientTokenAsync(this HttpClient client,
                                                                        Credentials credentials,
                                                                        CancellationToken cancellationToken = default)
        {
            return await RequestTokenAsync(client, credentials, cancellationToken).ConfigureAwait(false);
        }

        private static async Task<TokenResponse> RequestTokenAsync(HttpClient client, Credentials credentials, CancellationToken cancellationToken)
        {
            var tokenResponse = new TokenResponse();
            
            var content = new[]
            {
                    new KeyValuePair<string, string>("Username", credentials.Username),
                    new KeyValuePair<string, string>("Password", credentials.Password)
                };

            // Get data response
            var response = await client.PostAsync(authUrl, new FormUrlEncodedContent(content), cancellationToken);

            if (response == null || response?.Content == null || !response.IsSuccessStatusCode)
            {
                //return exception
                return tokenResponse;
            }

            // Parse the response body
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TokenResponse>(result);
        }
    }
}
