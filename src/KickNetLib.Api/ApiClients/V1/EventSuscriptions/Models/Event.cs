
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models
{
    /// <summary>
    /// Represents an event to be subscribed to, including the event name and version.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class with the specified event name and version.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="version">The version of the event subscription.</param>
        public Event(string eventName, int version)
        {
            Name = eventName;
            Version = version;
        }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version of the event subscription.
        /// </summary>
        [JsonPropertyName("version")]
        public long Version { get; set; }
    }
}
