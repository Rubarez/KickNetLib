
using KickNetLib.Client.Models.Args;

namespace KickNetLib.WebApi.Handlers.Steam
{
    /// <summary>
    /// Handles the event when the status of a livestream is updated.
    /// </summary>
    public class LivestreamStatusUpdatedHandler
    {
        private readonly ILogger<LivestreamStatusUpdatedHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LivestreamStatusUpdatedHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging information during the event handling.</param>
        public LivestreamStatusUpdatedHandler(ILogger<LivestreamStatusUpdatedHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the livestream status update event by logging the event data.
        /// </summary>
        /// <param name="sender">The object that triggered the event. Can be null if not applicable.</param>
        /// <param name="e">Event arguments containing the data related to the updated livestream status.</param>
        public void Handle(object sender, LivestreamStatusUpdatedEventArgs e)
        {
            // Logs the event data when the livestream status is updated.
            _logger.LogInformation("OnLivestreamStatusUpdated: {@data}", e.Data);
        }
    }
}
