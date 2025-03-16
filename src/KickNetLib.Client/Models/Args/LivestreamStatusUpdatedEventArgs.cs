
using KickNetLib.Client.Models.Payloads;

namespace KickNetLib.Client.Models.Args
{
    /// <summary>
    /// Represents the event arguments for when a livestream status is updated.
    /// This class wraps the payload data for a livestream-status-updated event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="LivestreamStatusUpdatedEventArgs"/> class.
    /// </remarks>
    /// <param name="data">The payload data for the livestream-status-updated event.</param>
    public class LivestreamStatusUpdatedEventArgs(LivestreamStatusUpdatedPayload data)
    {
        /// <summary>
        /// Gets the payload data associated with the livestream-status-updated event.
        /// </summary>
        public LivestreamStatusUpdatedPayload Data { get; } = data;
    }
}
