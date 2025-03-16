
using System.Text.Json.Serialization;

using KickNetLib.Client.Models.Payloads.Core;

namespace KickNetLib.Client.Models.Payloads
{
    /// <summary>
    /// Represents the payload data for a channel subscription renewal event.
    /// Contains details about the broadcaster, the subscriber, renewal duration, and the creation time.
    /// </summary>
    public partial class ChannelSubscriptionRenewalPayload
    {
        /// <summary>
        /// Gets or sets the broadcaster's information.
        /// Represents the user who owns the channel where the subscription renewal is made.
        /// </summary>
        [JsonPropertyName("broadcaster")]
        public KickUser Broadcaster { get; set; }

        /// <summary>
        /// Gets or sets the subscriber's information.
        /// Represents the user who has renewed their subscription to the broadcaster's channel.
        /// </summary>
        [JsonPropertyName("subscriber")]
        public KickUser Subscriber { get; set; }

        /// <summary>
        /// Gets or sets the duration of the renewed subscription.
        /// Represents the duration (in days) of the subscription after renewal.
        /// </summary>
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the subscription renewal event.
        /// Represents when the subscription renewal event was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
