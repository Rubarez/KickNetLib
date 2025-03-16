

using System.Text.Json.Serialization;

using KickNetLib.Client.Models.Payloads.Core;

namespace KickNetLib.Client.Models.Payloads
{
    /// <summary>
    /// Represents the payload data for a channel subscription gift event.
    /// Contains details about the broadcaster, the gifter, the giftees, and the creation time.
    /// </summary>
    public partial class ChannelSubscriptionGiftsPayload
    {
        /// <summary>
        /// Gets or sets the broadcaster's information.
        /// Represents the user who owns the channel where the subscription gifts are being sent.
        /// </summary>
        [JsonPropertyName("broadcaster")]
        public KickUser Broadcaster { get; set; }

        /// <summary>
        /// Gets or sets the gifter's information.
        /// Represents the user who is gifting the subscriptions.
        /// </summary>
        [JsonPropertyName("gifter")]
        public KickUser Gifter { get; set; }

        /// <summary>
        /// Gets or sets the list of giftees.
        /// Represents the users who are receiving the gifted subscriptions.
        /// </summary>
        [JsonPropertyName("giftees")]
        public List<KickUser> Giftees { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the subscription gift event.
        /// Represents when the subscription gifts were created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
