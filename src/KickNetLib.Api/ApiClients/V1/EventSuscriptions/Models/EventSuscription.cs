
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models
{
    /// <summary>
    /// Represents an event subscription with details about the event, broadcaster, and subscription metadata.
    /// </summary>
    public class EventSuscription
    {
        /// <summary>
        /// Gets or sets the application ID associated with the subscription.
        /// </summary>
        [JsonPropertyName("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the broadcaster user ID associated with the subscription.
        /// </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public long BroadcasterUserId { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the subscription.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the event name to which the subscription is tied.
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the subscription.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the method used for the subscription (e.g., webhook).
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the last update timestamp of the subscription.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the version of the subscription.
        /// </summary>
        [JsonPropertyName("version")]
        public long Version { get; set; }
    }
}
