
using KickNetLib.WebApi.Handlers.Channel;
using KickNetLib.WebApi.Handlers.Chat;
using KickNetLib.WebApi.Handlers.Steam;

namespace KickNetLib.WebApi.Handlers
{
    /// <summary>
    /// A container class that holds all the webhook handlers for various event types.
    /// </summary>
    public class WebHookHandlers
    {
        // Handler for chat messages sent events
        public ChatMessageSentHandler ChatMessageSentHandler { get; }

        // Handler for livestream status updated events
        public LivestreamStatusUpdatedHandler LivestreamStatusUpdatedHandler { get; }

        // Handler for channel subscription renewal events
        public ChannelSubscriptionRenewalHandler ChannelSubscriptionRenewalHandler { get; }

        // Handler for new channel subscription events
        public ChannelNewSubscriptionHandler ChannelNewSubscriptionHandler { get; }

        // Handler for gifted channel subscription events
        public ChannelGiftedSubscriptionHandler ChannelGiftedSubscriptionHandler { get; }

        // Handler for channel followed events
        public ChannelFollowedHandler ChannelFollowedHandler { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebHookHandlers"/> class.
        /// </summary>
        /// <param name="chatMessageSentHandler">The handler for chat message sent events.</param>
        /// <param name="livestreamStatusUpdatedHandler">The handler for livestream status updated events.</param>
        /// <param name="channelSubscriptionRenewalHandler">The handler for channel subscription renewal events.</param>
        /// <param name="channelNewSubscriptionHandler">The handler for new channel subscription events.</param>
        /// <param name="channelGiftedSubscriptionHandler">The handler for gifted channel subscription events.</param>
        /// <param name="channelFollowedHandler">The handler for channel followed events.</param>
        public WebHookHandlers(
                    ChatMessageSentHandler chatMessageSentHandler,
                    LivestreamStatusUpdatedHandler livestreamStatusUpdatedHandler,
                    ChannelSubscriptionRenewalHandler channelSubscriptionRenewalHandler,
                    ChannelNewSubscriptionHandler channelNewSubscriptionHandler,
                    ChannelGiftedSubscriptionHandler channelGiftedSubscriptionHandler,
                    ChannelFollowedHandler channelFollowedHandler)
        {
            // Assigns the handlers to the properties
            ChatMessageSentHandler = chatMessageSentHandler;
            LivestreamStatusUpdatedHandler = livestreamStatusUpdatedHandler;
            ChannelSubscriptionRenewalHandler = channelSubscriptionRenewalHandler;
            ChannelNewSubscriptionHandler = channelNewSubscriptionHandler;
            ChannelGiftedSubscriptionHandler = channelGiftedSubscriptionHandler;
            ChannelFollowedHandler = channelFollowedHandler;
        }
    }
}
