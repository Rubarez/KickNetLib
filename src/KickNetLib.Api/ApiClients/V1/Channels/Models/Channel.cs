
using System.Text.Json.Serialization;

using KickNetLib.Api.ApiClients.V1.Categories.Models;

namespace KickNetLib.Api.ApiClients.V1.Channels.Models
{
    /// <summary>
    /// Represents a channel in the Kick API.
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// Gets or sets the banner picture URL for the channel.
        /// </summary>
        [JsonPropertyName("banner_picture")]
        public string BannerPicture { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the broadcaster user associated with the channel.
        /// </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public long BroadcasterUserId { get; set; }

        /// <summary>
        /// Gets or sets the category of the channel.
        /// </summary>
        [JsonPropertyName("category")]
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the description of the channel.
        /// </summary>
        [JsonPropertyName("channel_description")]
        public string ChannelDescription { get; set; }

        /// <summary>
        /// Gets or sets the URL-friendly string identifier (slug) for the channel.
        /// </summary>
        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the stream associated with the channel.
        /// </summary>
        [JsonPropertyName("stream")]
        public Stream Stream { get; set; }

        /// <summary>
        /// Gets or sets the title of the stream.
        /// </summary>
        [JsonPropertyName("stream_title")]
        public string StreamTitle { get; set; }
    }
}
