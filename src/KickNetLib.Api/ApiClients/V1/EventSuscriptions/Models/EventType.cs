
namespace KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models
{
    /// <summary>
    /// Represents the different event types available for subscription.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Represents the event type for a chat message being sent.
        /// </summary>
        ChatMessageSent,

        /// <summary>
        /// Represents the event type when a channel is followed.
        /// </summary>
        ChannelFollowed,

        /// <summary>
        /// Represents the event type for a channel subscription renewal.
        /// </summary>
        ChannelSubscriptionRenewal,

        /// <summary>
        /// Represents the event type for channel subscription gifts.
        /// </summary>
        ChannelSubscriptionGifts,

        /// <summary>
        /// Represents the event type for a new channel subscription.
        /// </summary>
        ChannelSubscriptionNew,

        /// <summary>
        /// Represents the event type when the livestream status is updated.
        /// </summary>
        LivestreamStatusUpdated
    }
}
