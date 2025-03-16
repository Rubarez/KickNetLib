
using KickNetLib.Client.Models.Args;

namespace KickNetLib.WebApi.Handlers.Channel
{
    /// <summary>
    /// Handles the event when a gifted subscription is given to a channel.
    /// </summary>
    public class ChannelGiftedSubscriptionHandler
    {
        private readonly ILogger<ChannelGiftedSubscriptionHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelGiftedSubscriptionHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging information during the event handling.</param>
        public ChannelGiftedSubscriptionHandler(ILogger<ChannelGiftedSubscriptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the gifted subscription event by logging the event data.
        /// </summary>
        /// <param name="sender">The object that triggered the event. Can be null if not applicable.</param>
        /// <param name="e">Event arguments containing the data related to the gifted subscription.</param>
        public void Handle(object sender, ChannelGiftedSubscriptionEventArgs e)
        {
            // Logs the event data when a subscription is gifted to a channel.
            _logger.LogInformation("OnChannelGiftedSubscription: {@data}", e.Data);
        }
    }
}
