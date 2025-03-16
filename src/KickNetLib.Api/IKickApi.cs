
using KickNetLib.Api.ApiClients;
using KickNetLib.Api.Auth;

namespace KickNetLib.Api
{
    /// <summary>
    /// Defines the contract for accessing various Kick API endpoints.
    /// This interface includes properties for interacting with categories, users, channels, public keys,
    /// event subscriptions, chat functionality, and authentication.
    /// </summary>
    public interface IKickApi
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="CategoryApiClient"/> for interacting with categories.
        /// </summary>
        CategoryApiClient Categories { get; }

        /// <summary>
        /// Gets the <see cref="UserApiClient"/> for managing users.
        /// </summary>
        UserApiClient Users { get; }

        /// <summary>
        /// Gets the <see cref="ChannelApiClient"/> for managing channels.
        /// </summary>
        ChannelApiClient Channels { get; }

        /// <summary>
        /// Gets the <see cref="PublicKeyApiClient"/> for managing public keys.
        /// </summary>
        PublicKeyApiClient PublicKey { get; }

        /// <summary>
        /// Gets the <see cref="EventSuscriptionApiClient"/> for subscribing to and managing events.
        /// </summary>
        EventSuscriptionApiClient EventsSuscriptions { get; }

        /// <summary>
        /// Gets the <see cref="ChatApiClient"/> for interacting with chat functionality.
        /// </summary>
        ChatApiClient Chat { get; }

        /// <summary>
        /// Gets the <see cref="TokenApiClient"/> for handling authentication and token management.
        /// </summary>
        TokenApiClient Token { get; }
        KickOAuthClient Authentication { get; }

        #endregion
    }
}
