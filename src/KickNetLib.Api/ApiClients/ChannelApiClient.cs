using Microsoft.Extensions.Logging;
using KickNetLib.Api.Models.Core;
using KickNetLib.Api.Models.Settings;
using KickNetLib.Api.ApiClients.V1.Channels.Models;

namespace KickNetLib.Api.ApiClients
{

    /// <summary>
    /// Client for interacting with the channels-related API endpoints in the Kick API.
    /// Inherits from BaseApiClient to provide common HTTP request functionality.
    /// </summary>
    public class ChannelApiClient : BaseApiClient
    {
        #region Members

        /// <summary>
        /// The resource path for channels.
        /// </summary>
        private const string UrlResourcePath = "channels";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ChannelApiClient class.
        /// </summary>
        /// <param name="logger">Logger for logging requests and responses.</param>
        /// <param name="kickSettings">Settings for Kick API configuration, such as access token and base URL.</param>
        public ChannelApiClient(ILogger logger, KickApiSettings kickSettings) : base(logger, kickSettings) { }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Retrieves a list of channels by their broadcaster user IDs.
        /// </summary>
        /// <param name="broadcasterUsersId">A collection of broadcaster user IDs.</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A list of channels corresponding to the provided broadcaster user IDs.</returns>
        /// <exception cref="ArgumentException">Thrown if no broadcaster user IDs are provided.</exception>
        public async Task<List<Channel>> GetChannelsByIdAsync(ICollection<int> broadcasterUsersId, string accessToken = null)
        {
            if (broadcasterUsersId == null || broadcasterUsersId.Count == 0)
            {
                throw new ArgumentException("Broadcaster user IDs cannot be empty.", nameof(broadcasterUsersId));
            }

            var queryParams = broadcasterUsersId
                .Distinct()
                .Select(id => new KeyValuePair<string, string>("broadcaster_user_id", id.ToString()))
                .ToList();

            return await GetAsync<List<Channel>>(
                UrlResourcePath,
                ApiVersion.V1,
                queryParams,
                accessToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the channel's category and stream title.
        /// </summary>
        /// <param name="categoryId">The new category ID for the channel (default is 0, meaning no change).</param>
        /// <param name="title">The new stream title (default is an empty string, meaning no change).</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A boolean indicating whether the update was successful.</returns>
        public async Task<bool> UpdateChannelAsync(int categoryId = 0, string title = "", string accessToken = null)
        {
            var updateChannelRequest = new UpdateChannelRequest
            {
                CategoryId = categoryId,
                StreamTitle = title
            };

            return await PatchAsync(UrlResourcePath, ApiVersion.V1, updateChannelRequest, accessToken).ConfigureAwait(false);
        }

        #endregion
    }
}
