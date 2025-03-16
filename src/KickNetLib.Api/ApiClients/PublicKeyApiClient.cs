
using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.Core;
using KickNetLib.Api.ApiClients.V1.PublicKey.Models;
using KickNetLib.Api.Models.Settings;

namespace KickNetLib.Api.ApiClients
{
    /// <summary>
    /// Client for interacting with public key-related API endpoints in the Kick API.
    /// Inherits from BaseApiClient to provide common HTTP request functionality.
    /// </summary>
    public class PublicKeyApiClient : BaseApiClient
    {
        #region Members

        /// <summary>
        /// The resource path for public key-related API calls.
        /// </summary>
        private const string UrlResourcePath = "public-key";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the PublicKeyApiClient class.
        /// </summary>
        /// <param name="logger">Logger for logging requests and responses.</param>
        /// <param name="kickSettings">Settings for Kick API configuration, such as access token and base URL.</param>
        public PublicKeyApiClient(ILogger logger, KickApiSettings kickSettings) : base(logger, kickSettings) { }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Retrieves the public key data from the API.
        /// Makes a GET request to the 'public-key' endpoint.
        /// </summary>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A PublicKeyData object containing the public key information.</returns>
        public async Task<PublicKeyData> GetPublicKeyAsync(string accessToken = null)
        {
            var url = $"{UrlResourcePath}";

            return await GetAsync<PublicKeyData>(url, ApiVersion.V1, null, accessToken).ConfigureAwait(false);
        }

        #endregion
    }
}
