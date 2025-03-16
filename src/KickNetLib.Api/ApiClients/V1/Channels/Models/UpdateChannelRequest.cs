
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.Channels.Models
{
    /// <summary>
    /// Represents a request to update channel information.
    /// </summary>
    public class UpdateChannelRequest
    {
        /// <summary>
        /// Gets or sets the category ID to update the channel's category.
        /// </summary>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the title of the stream associated with the channel.
        /// </summary>
        [JsonPropertyName("stream_title")]
        public string StreamTitle { get; set; }
    }
}
