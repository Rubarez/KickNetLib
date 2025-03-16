
using KickNetLib.Client.Models.Payloads;

namespace KickNetLib.Client.Models.Args
{
    /// <summary>
    /// Represents the event arguments for when a new subscription occurs on a channel.
    /// This class wraps the payload data for a channel-new-subscription event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ChannelNewSubscriptionEventArgs"/> class.
    /// </remarks>
    /// <param name="data">The payload data for the channel-new-subscription event.</param>
    public class ChannelNewSubscriptionEventArgs(ChannelSubscriptionNewPayload data)
    {
        /// <summary>
        /// Gets the payload data associated with the channel-new-subscription event.
        /// </summary>
        public ChannelSubscriptionNewPayload Data { get; } = data;
    }
}
