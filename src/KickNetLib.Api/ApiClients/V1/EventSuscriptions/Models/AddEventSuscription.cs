
using System.Text.Json.Serialization;

using KickNetLib.Api.Helpers;

namespace KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models
{
    /// <summary>
    /// Represents a request to add an event subscription, including the events to subscribe to and the method of subscription.
    /// </summary>
    public class AddEventSuscription
    {
        // Constant method name used for the subscription
        private const string MethodName = "webhook";

        /// <summary>
        /// Initializes a new instance of the <see cref="AddEventSuscription"/> class with an empty list of events.
        /// </summary>
        public AddEventSuscription()
        {
            Events = [];
        }

        /// <summary>
        /// Adds a new event to the subscription list.
        /// </summary>
        /// <param name="eventType">The type of the event to subscribe to.</param>
        /// <param name="version">The version of the event subscription.</param>
        public void AddEvent(EventType eventType, int version)
        {
            // Adding a new event with the provided event type and version
            Events.Add(new Event(ToolEventType.GetEventName(eventType), version));
        }

        /// <summary>
        /// Gets the list of events to which the user is subscribing.
        /// </summary>
        [JsonPropertyName("events")]
        public List<Event> Events { get; }

        /// <summary>
        /// Gets the method used for the subscription. This will always return "webhook".
        /// </summary>
        [JsonPropertyName("method")]
        public string Method => MethodName;
    }
}
