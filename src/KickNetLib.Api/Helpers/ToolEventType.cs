using KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models;
using KickNetLib.Shared.Models.WebHooks;

namespace KickNetLib.Api.Helpers
{
    /// <summary>
    /// A helper class for handling event types and mapping them to corresponding webhook event names.
    /// </summary>
    public static class ToolEventType
    {
        /// <summary>
        /// Maps an <see cref="EventType"/> to its corresponding event name used in the webhook system.
        /// This method returns the event name for different types of events such as chat messages, channel follow events, etc.
        /// </summary>
        /// <param name="type">The <see cref="EventType"/> to be converted to a webhook event name.</param>
        /// <returns>The webhook event name as a string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the provided event type is not recognized.</exception>
        public static string GetEventName(this EventType type)
        {
            return type switch
            {
                EventType.ChatMessageSent => WebhookEventTypes.ChatMessageSent,
                EventType.ChannelFollowed => WebhookEventTypes.ChannelFollowed,
                EventType.ChannelSubscriptionRenewal => WebhookEventTypes.ChannelSubscriptionRenewal,
                EventType.ChannelSubscriptionGifts => WebhookEventTypes.ChannelGiftedSubscription,
                EventType.ChannelSubscriptionNew => WebhookEventTypes.ChannelNewSubscription,
                EventType.LivestreamStatusUpdated => WebhookEventTypes.LivestreamStatusUpdated,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
