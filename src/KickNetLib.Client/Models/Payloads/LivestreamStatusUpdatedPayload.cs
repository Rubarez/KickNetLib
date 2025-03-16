
using System.Text.Json.Serialization;

using KickNetLib.Client.Models.Payloads.Core;

namespace KickNetLib.Client.Models.Payloads
{
    /// <summary>
    /// Represents the payload data for a livestream status update event.
    /// Contains information about the broadcaster, livestream status, title, and timestamps.
    /// </summary>
    public partial class LivestreamStatusUpdatedPayload
    {
        /// <summary>
        /// Gets or sets the broadcaster's information.
        /// Represents the user who owns the channel being updated.
        /// </summary>
        [JsonPropertyName("broadcaster")]
        public KickUser Broadcaster { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the broadcaster is live.
        /// True if the broadcaster is currently live, false otherwise.
        /// </summary>
        [JsonPropertyName("is_live")]
        public bool IsLive { get; set; }

        /// <summary>
        /// Gets or sets the title of the livestream.
        /// Represents the title or description of the livestream event.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the livestream started.
        /// Represents the exact date and time when the livestream began.
        /// </summary>
        [JsonPropertyName("started_at")]
        public DateTimeOffset StartedAt { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the livestream ended, if applicable.
        /// Can be null or an object depending on whether the livestream is still ongoing.
        /// </summary>
        [JsonPropertyName("ended_at")]
        public object EndedAt { get; set; }
    }
}
