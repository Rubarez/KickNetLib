
using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.Settings;
using KickNetLib.Api.ApiClients;
using KickNetLib.Api.Auth;

namespace KickNetLib.Api
{
    /// <summary>
    /// Represents the API client for interacting with various Kick API endpoints.
    /// This class provides access to the authentication, event subscriptions, categories,
    /// users, channels, chat, and public key related API clients.
    /// </summary>
    public class KickApi : IKickApi
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KickApi"/> class.
        /// This constructor sets up the necessary API clients based on the provided settings.
        /// </summary>
        /// <param name="settings">Configuration settings for the API clients.</param>
        /// <param name="logger">Optional logger for logging API activities and errors.</param>

        public KickApi(KickApiSettings settings, ILogger<KickApi> logger = null)
        {
            logger ??= CreateDefaultLogger();

            Token = new TokenApiClient(logger, settings);
            EventsSuscriptions = new EventSuscriptionApiClient(logger, settings);
            Categories = new CategoryApiClient(logger, settings);
            Users = new UserApiClient(logger, settings);
            Channels = new ChannelApiClient(logger, settings);
            Chat = new ChatApiClient(logger, settings);
            PublicKey = new PublicKeyApiClient(logger, settings);

            Authentication = new KickOAuthClient(settings.KickOAuthSettings);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates a default logger when none is provided.
        /// </summary>
        /// <returns>The default logger for KickClient.</returns>
        private static ILogger<KickApi> CreateDefaultLogger()
        {
            return LoggerFactory.Create(builder => builder.AddConsole())
                .CreateLogger<KickApi>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Provides methods for token operations.
        /// </summary>

        public KickOAuthClient Authentication { get; }

        /// <summary>
        /// Provides methods for token operations.
        /// </summary>

        public TokenApiClient Token { get; }

        /// <summary>
        /// Provides methods for event subscription management.
        /// </summary>
        public EventSuscriptionApiClient EventsSuscriptions { get; }

        /// <summary>
        /// Provides methods for interacting with categories.
        /// </summary>
        public CategoryApiClient Categories { get; }

        /// <summary>
        /// Provides methods for managing users.
        /// </summary>
        public UserApiClient Users { get; }

        /// <summary>
        /// Provides methods for managing channels.
        /// </summary>
        public ChannelApiClient Channels { get; }

        /// <summary>
        /// Provides methods for managing chat functionality.
        /// </summary>
        public ChatApiClient Chat { get; }

        /// <summary>
        /// Provides methods for accessing public keys.
        /// </summary>
        public PublicKeyApiClient PublicKey { get; }

        #endregion
    }
}
