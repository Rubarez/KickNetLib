
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.Categories.Models
{
    /// <summary>
    /// Represents a category in the Kick API.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the thumbnail image for the category.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
