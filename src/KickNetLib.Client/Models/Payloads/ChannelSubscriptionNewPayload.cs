
using System.Text.Json.Serialization;

using KickNetLib.Client.Models.Payloads.Core;

namespace KickNetLib.Client.Models.Payloads
{
    /// <summary>
    /// Represents the payload data for a new channel subscription event.
    /// Contains details about the broadcaster, the subscriber, subscription duration, and the creation time.
    /// </summary>
    public partial class ChannelSubscriptionNewPayload
    {
        /// <summary>
        /// Gets or sets the broadcaster's information.
        /// Represents the user who owns the channel where the subscription is made.
        /// </summary>
        [JsonPropertyName("broadcaster")]
        public KickUser Broadcaster { get; set; }

        /// <summary>
        /// Gets or sets the subscriber's information.
        /// Represents the user who has subscribed to the broadcaster's channel.
        /// </summary>
        [JsonPropertyName("subscriber")]
        public KickUser Subscriber { get; set; }

        /// <summary>
        /// Gets or sets the duration of the subscription.
        /// Represents the duration (in days) of the subscription made by the subscriber.
        /// </summary>
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the subscription event.
        /// Represents when the new subscription event was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
