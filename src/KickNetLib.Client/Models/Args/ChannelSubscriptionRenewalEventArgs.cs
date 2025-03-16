
using KickNetLib.Client.Models.Payloads;

namespace KickNetLib.Client.Models.Args
{
    /// <summary>
    /// Represents the event arguments for when a channel subscription is renewed.
    /// This class wraps the payload data for a channel-subscription-renewal event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ChannelSubscriptionRenewalEventArgs"/> class.
    /// </remarks>
    /// <param name="data">The payload data for the channel-subscription-renewal event.</param>
    public class ChannelSubscriptionRenewalEventArgs(ChannelSubscriptionRenewalPayload data)
    {
        /// <summary>
        /// Gets the payload data associated with the channel-subscription-renewal event.
        /// </summary>
        public ChannelSubscriptionRenewalPayload Data { get; } = data;
    }
}
