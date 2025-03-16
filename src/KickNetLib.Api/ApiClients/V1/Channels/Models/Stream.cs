
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.Channels.Models
{
    /// <summary>
    /// Represents the stream associated with a channel.
    /// </summary>
    public class Stream
    {
        /// <summary>
        /// Gets or sets a value indicating whether the stream is currently live.
        /// </summary>
        [JsonPropertyName("is_live")]
        public bool IsLive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stream is marked as mature content.
        /// </summary>
        [JsonPropertyName("is_mature")]
        public bool IsMature { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier key for the stream.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the language of the stream's content.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the start time of the stream.
        /// </summary>
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the URL of the stream.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the number of viewers currently watching the stream.
        /// </summary>
        [JsonPropertyName("viewer_count")]
        public long ViewerCount { get; set; }
    }
}
