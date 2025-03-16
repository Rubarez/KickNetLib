
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models
{
    /// <summary>
    /// Represents the response received when adding an event subscription.
    /// </summary>
    public class AddEnventSuscriptionResponse
    {
        /// <summary>
        /// Gets or sets the error message if the subscription attempt failed. If successful, this will be null or empty.
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the name of the event type to which the subscription belongs.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the subscription.
        /// </summary>
        [JsonPropertyName("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the version of the event subscription.
        /// </summary>
        [JsonPropertyName("version")]
        public long Version { get; set; }
    }
}
