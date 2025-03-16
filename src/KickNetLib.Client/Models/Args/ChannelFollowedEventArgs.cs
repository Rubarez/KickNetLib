
using KickNetLib.Client.Models.Payloads;

namespace KickNetLib.Client.Models.Args
{
    /// <summary>
    /// Represents the event arguments for when a channel is followed.
    /// This class wraps the payload data for a channel-followed event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ChannelFollowedEventArgs"/> class.
    /// </remarks>
    /// <param name="data">The payload data for the channel-followed event.</param>
    public class ChannelFollowedEventArgs(ChannelFollowedPayload data)
    {
        /// <summary>
        /// Gets the payload data associated with the channel-followed event.
        /// </summary>
        public ChannelFollowedPayload Data { get; } = data;
    }
}
