
using KickNetLib.Client.Models.Args;

namespace KickNetLib.WebApi.Handlers.Channel
{
    /// <summary>
    /// Handles the event when a channel subscription is renewed.
    /// </summary>
    public class ChannelSubscriptionRenewalHandler
    {
        private readonly ILogger<ChannelSubscriptionRenewalHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelSubscriptionRenewalHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging information during the event handling.</param>
        public ChannelSubscriptionRenewalHandler(ILogger<ChannelSubscriptionRenewalHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the subscription renewal event by logging the event data.
        /// </summary>
        /// <param name="sender">The object that triggered the event. Can be null if not applicable.</param>
        /// <param name="e">Event arguments containing the data related to the subscription renewal.</param>
        public void Handle(object sender, ChannelSubscriptionRenewalEventArgs e)
        {
            // Logs the event data when a channel subscription is renewed.
            _logger.LogInformation("OnChannelSubscriptionRenewal: {@data}", e.Data);
        }
    }
}
