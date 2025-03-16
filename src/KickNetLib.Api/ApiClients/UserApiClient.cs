
using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.Core;
using KickNetLib.Api.ApiClients.V1.Users.Models;
using KickNetLib.Api.Models.Settings;

namespace KickNetLib.Api.ApiClients
{
    /// <summary>
    /// UserApiClient class for interacting with the user-related endpoints of the Kick API.
    /// Inherits from BaseApiClient to leverage common HTTP request functionality.
    /// </summary>
    public class UserApiClient : BaseApiClient
    {
        #region Members

        /// <summary>
        /// The base resource path for user-related API calls.
        /// </summary>
        private const string UrlResourcePath = "users";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the UserApiClient class.
        /// </summary>
        /// <param name="logger">An instance of ILogger used for logging.</param>
        /// <param name="kickSettings">Configuration settings for the Kick API client, including the access token and base URL.</param>
        public UserApiClient(ILogger logger, KickApiSettings kickSettings) : base(logger, kickSettings) { }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Retrieves the currently authenticated user (me).
        /// Makes a GET request to the user resource and returns the first user found, or a default empty user if not found.
        /// </summary>
        /// <param name="accessToken">The optional access token used for authentication. If null, uses the token from KickApiSettings.</param>
        /// <returns>A User object representing the currently authenticated user.</returns>
        public async Task<User> GetUserMeAsync(string accessToken = null)
        {
            var url = $"{UrlResourcePath}";

            var users = await GetAsync<List<User>>(url, ApiVersion.V1, null, accessToken).ConfigureAwait(false);
            return users.FirstOrDefault() ?? new User();
        }

        /// <summary>
        /// Retrieves a list of users by their user IDs.
        /// This method accepts a collection of user IDs, ensures they are distinct, and then sends a GET request to the API.
        /// </summary>
        /// <param name="userIds">A collection of user IDs to look up.</param>
        /// <param name="accessToken">The optional access token for authentication.</param>
        /// <returns>A list of User objects corresponding to the provided user IDs.</returns>
        /// <exception cref="ArgumentException">Thrown if the provided user IDs collection is empty.</exception>
        public async Task<List<User>> GetUserByIdsAsync(ICollection<int> userIds, string accessToken = null)
        {
            if (userIds.Count == 0)
                throw new ArgumentException("User Ids cannot be empty.", nameof(userIds));

            // Build query parameters
            var queryParams = userIds.Distinct().Select(id => new KeyValuePair<string, string>("id", id.ToString())).ToList();

            // Call the base GetAsync method
            return await GetAsync<List<User>>(UrlResourcePath, ApiVersion.V1, queryParams, accessToken).ConfigureAwait(false);
        }

        #endregion
    }
}
