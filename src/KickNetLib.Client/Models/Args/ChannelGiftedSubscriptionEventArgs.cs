
using KickNetLib.Client.Models.Payloads;

namespace KickNetLib.Client.Models.Args
{
    /// <summary>
    /// Represents the event arguments for when a gifted subscription occurs.
    /// This class wraps the payload data for a channel-gifted-subscription event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ChannelGiftedSubscriptionEventArgs"/> class.
    /// </remarks>
    /// <param name="data">The payload data for the channel-gifted-subscription event.</param>
    public class ChannelGiftedSubscriptionEventArgs(ChannelSubscriptionGiftsPayload data)
    {
        /// <summary>
        /// Gets the payload data associated with the channel-gifted-subscription event.
        /// </summary>
        public ChannelSubscriptionGiftsPayload Data { get; } = data;
    }
}
