
using System.Text.Json.Serialization;

using KickNetLib.Client.Models.Payloads.Core;

namespace KickNetLib.Client.Models.Payloads
{
    /// <summary>
    /// Represents the payload data for a channel followed event.
    /// Contains details about the broadcaster and the follower.
    /// </summary>
    public partial class ChannelFollowedPayload
    {
        /// <summary>
        /// Gets or sets the broadcaster information.
        /// Represents the user who owns the channel being followed.
        /// </summary>
        [JsonPropertyName("broadcaster")]
        public KickUser Broadcaster { get; set; }

        /// <summary>
        /// Gets or sets the follower information.
        /// Represents the user who is following the broadcaster's channel.
        /// </summary>
        [JsonPropertyName("follower")]
        public KickUser Follower { get; set; }
    }
}
