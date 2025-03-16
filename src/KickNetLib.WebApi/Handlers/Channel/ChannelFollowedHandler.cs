
using KickNetLib.Client.Models.Args;

namespace KickNetLib.WebApi.Handlers.Channel
{
    /// <summary>
    /// Handles the event when a channel is followed.
    /// </summary>
    public class ChannelFollowedHandler
    {
        private readonly ILogger<ChannelFollowedHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelFollowedHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging information during the event handling.</param>
        public ChannelFollowedHandler(ILogger<ChannelFollowedHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the channel followed event by logging the event data.
        /// </summary>
        /// <param name="sender">The object that triggered the event. Can be null if not applicable.</param>
        /// <param name="e">Event arguments containing the data related to the followed channel.</param>
        public void Handle(object sender, ChannelFollowedEventArgs e)
        {
            // Logs the event data when a channel is followed.
            _logger.LogInformation("OnChannelFollowed: {@data}", e.Data);
        }
    }
}
