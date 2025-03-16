
namespace KickNetLib.Api.Auth
{
    /// <summary>
    /// A static class that defines various authorization scopes for accessing resources
    /// and performing actions on the Kick platform. These scopes are typically used in OAuth
    /// authentication to specify the permissions granted to the application.
    /// </summary>
    public static class KickScope
    {
        /// <summary>
        /// View user information in Kick including username, streamer ID, etc.
        /// </summary>
        public const string UserRead = "user:read";
        /// <summary>
        /// View channel information in Kick including channel description, category, etc.
        /// </summary>
        public const string ChannelRead = "channel:read";
        /// <summary>
        /// Update livestream metadata for a channel based on the channel ID
        /// </summary>
        public const string ChannelWrite = "channel:write";
        /// <summary>
        /// Send chat messages and allow chat bots to post in your chat
        /// </summary>
        public const string ChatWrite = "chat:write";
        /// <summary>
        /// Read a user's stream URL and stream key
        /// </summary>
        public const string SteamkeyRead = "streamkey:read";
        /// <summary>
        /// Subscribe to all channel events on Kick e.g. chat messages, follows, subscriptions
        /// </summary>
        public const string EventsSuscribe = "events:subscribe";

        /// <summary>
        /// Returning all scopes in a collection
        /// </summary>
        public static ICollection<string> AllScopes
        {
            get { return [UserRead, ChannelRead, ChannelWrite, ChatWrite, SteamkeyRead, EventsSuscribe]; }
        }

    }
}
