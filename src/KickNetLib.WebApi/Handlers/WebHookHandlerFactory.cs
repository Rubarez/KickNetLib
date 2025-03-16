
using KickNetLib.WebApi.Handlers.Channel;
using KickNetLib.WebApi.Handlers.Chat;
using KickNetLib.WebApi.Handlers.Steam;

namespace KickNetLib.WebApi.Handlers
{
    /// <summary>
    /// Factory class that creates and resolves webhook handlers for different event types.
    /// </summary>
    public class WebHookHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebHookHandlerFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider used for dependency injection (DI) to resolve handler instances.</param>
        public WebHookHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Factory method to resolve and create all the necessary webhook handlers at once.
        /// </summary>
        /// <returns>A <see cref="WebHookHandlers"/> object containing all the resolved handlers for different webhook events.</returns>
        public WebHookHandlers CreateHandlers()
        {
            // Resolves the necessary handler instances from the service provider
            var chatMessageSentHandler = _serviceProvider.GetRequiredService<ChatMessageSentHandler>();
            var livestreamStatusUpdatedHandler = _serviceProvider.GetRequiredService<LivestreamStatusUpdatedHandler>();
            var channelSubscriptionRenewalHandler = _serviceProvider.GetRequiredService<ChannelSubscriptionRenewalHandler>();
            var channelNewSubscriptionHandler = _serviceProvider.GetRequiredService<ChannelNewSubscriptionHandler>();
            var channelGiftedSubscriptionHandler = _serviceProvider.GetRequiredService<ChannelGiftedSubscriptionHandler>();
            var channelFollowedHandler = _serviceProvider.GetRequiredService<ChannelFollowedHandler>();

            // Returns a WebHookHandlers object containing all the handlers
            return new WebHookHandlers(
                chatMessageSentHandler,
                livestreamStatusUpdatedHandler,
                channelSubscriptionRenewalHandler,
                channelNewSubscriptionHandler,
                channelGiftedSubscriptionHandler,
                channelFollowedHandler
            );
        }
    }
}
