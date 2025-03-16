
using KickNetLib.Client.Models.Args;

namespace KickNetLib.WebApi.Handlers.Channel
{
    /// <summary>
    /// Handles the event when a new subscription is made to a channel.
    /// </summary>
    public class ChannelNewSubscriptionHandler
    {
        private readonly ILogger<ChannelNewSubscriptionHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelNewSubscriptionHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging information during the event handling.</param>
        public ChannelNewSubscriptionHandler(ILogger<ChannelNewSubscriptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the new subscription event by logging the event data.
        /// </summary>
        /// <param name="sender">The object that triggered the event. Can be null if not applicable.</param>
        /// <param name="e">Event arguments containing the data related to the new subscription.</param>
        public void Handle(object sender, ChannelNewSubscriptionEventArgs e)
        {
            // Logs the event data when a new subscription is made to a channel.
            _logger.LogInformation("OnChannelNewSubscription: {@data}", e.Data);
        }
    }
}
