
using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.Settings;
using KickNetLib.Api.ApiClients.V1.Chat.Models;
using KickNetLib.Api.Models.Core;

namespace KickNetLib.Api.ApiClients
{
    /// <summary>
    /// Client for interacting with the chat-related API endpoints in the Kick API.
    /// Inherits from BaseApiClient to provide common HTTP request functionality.
    /// </summary>
    public class ChatApiClient : BaseApiClient
    {
        #region Members

        /// <summary>
        /// The resource path for chat messages.
        /// </summary>
        private const string UrlResourcePath = "chat";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ChatApiClient class.
        /// </summary>
        /// <param name="logger">Logger for logging requests and responses.</param>
        /// <param name="kickSettings">Settings for Kick API configuration, such as access token and base URL.</param>
        public ChatApiClient(ILogger logger, KickApiSettings kickSettings) : base(logger, kickSettings) { }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Sends a message as a bot to the chat API.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A response indicating the result of the message sending.</returns>
        /// <exception cref="ArgumentException">Thrown if the message is null, empty, or whitespace.</exception>
        public async Task<SendMessageResponse> SendMessageAsBotAsync(string message, string accessToken = null)
        {
            // Validate the message
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message cannot be null, empty, or whitespace.", nameof(message));
            }

            var request = new SendMessageRequest(message, MessageType.bot);

            return await PostAsync<SendMessageResponse, SendMessageRequest>(
                UrlResourcePath, ApiVersion.V1, request, accessToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a message as a user to the chat API.
        /// </summary>
        /// <param name="broadcasterUserId">The ID of the broadcaster user.</param>
        /// <param name="message">The message to send.</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A response indicating the result of the message sending.</returns>
        /// <exception cref="ArgumentException">Thrown if the message is null, empty, or whitespace, or if the broadcasterUserId is invalid.</exception>
        public async Task<SendMessageResponse> SendMessageAsUserAsync(
            int broadcasterUserId,
            string message,
            string accessToken = null)
        {
            // Validate the message and broadcasterUserId
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message cannot be null, empty, or whitespace.", nameof(message));
            }

            if (broadcasterUserId <= 0)
            {
                throw new ArgumentException("Broadcaster user ID must be a positive integer.", nameof(broadcasterUserId));
            }

            var request = new SendMessageRequest(message, MessageType.user)
            {
                BroadcasterId = broadcasterUserId
            };

            return await PostAsync<SendMessageResponse, SendMessageRequest>(
                UrlResourcePath, ApiVersion.V1, request, accessToken).ConfigureAwait(false);
        }

        #endregion
    }
}
