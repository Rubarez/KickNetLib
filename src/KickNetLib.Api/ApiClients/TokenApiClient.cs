
using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.Core;
using KickNetLib.Api.Models.Settings;
using KickNetLib.Api.ApiClients.V1.Token.Models;

namespace KickNetLib.Api.ApiClients
{
    /// <summary>
    /// TokenApiClient class for interacting with the token-related endpoints of the Kick API.
    /// Inherits from BaseApiClient to leverage common HTTP request functionality.
    /// </summary>
    public class TokenApiClient : BaseApiClient
    {
        #region Members

        /// <summary>
        /// The base resource path for token-related API calls.
        /// </summary>
        private const string UrlResourcePath = "token";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the TokenApiClient class.
        /// </summary>
        /// <param name="logger">An instance of ILogger used for logging.</param>
        /// <param name="kickSettings">Configuration settings for the Kick API client, including the access token and base URL.</param>
        public TokenApiClient(ILogger logger, KickApiSettings kickSettings) : base(logger, kickSettings) { }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Introspects a given access token to retrieve information about its validity and associated metadata.
        /// Sends a POST request to the 'introspect' endpoint of the token resource.
        /// </summary>
        /// <param name="accessToken">The optional access token to introspect. If null, the token from KickApiSettings is used.</param>
        /// <returns>A TokenIntrospect object containing information about the access token's status.</returns>
        public async Task<TokenIntrospect> IntrospectTokenAsync(string accessToken = null)
        {
            var url = $"{UrlResourcePath}/introspect";

            return await PostAsync<TokenIntrospect>(url, ApiVersion.V1, accessToken).ConfigureAwait(false);
        }

        #endregion
    }
}
