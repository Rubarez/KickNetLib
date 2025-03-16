
using System.Net.Http.Headers;

using KickNetLib.Api.Models.Core;

namespace KickNetLib.Api.Helpers
{
    /// <summary>
    /// A utility class to help set authorization tokens on an HttpClient's request headers.
    /// This is useful for setting the authorization scheme and token to interact with secure APIs.
    /// </summary>
    public static class ToolToken
    {
        /// <summary>
        /// Sets the authorization token for HTTP requests made by the provided HttpClient.
        /// This method updates the HttpClient's DefaultRequestHeaders to include the specified scheme and token.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to set the token on.</param>
        /// <param name="scheme">The authentication scheme (e.g., "Bearer", "Basic").</param>
        /// <param name="token">The token string to use for authentication.</param>
        public static void SetToken(this HttpClient httpClient, string scheme, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        }
    }
}
