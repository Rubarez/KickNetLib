
using System.Text.Json;

using KickNetLib.Client.Models.Args;
using KickNetLib.Client.Models.Payloads;
using KickNetLib.Shared.Models.WebHooks;

namespace KickNetLib.Client.Webhooks
{
    /// <summary>
    /// The WebHookEventHandler class processes incoming webhook events based on event types. It deserializes the event payloads 
    /// and triggers corresponding events in the <see cref="WebHookEvent"/> object.
    /// </summary>
    public class WebHookEventManager
    {
        #region Members

        private readonly WebHookEvent _events;
        private readonly Dictionary<string, Action<string>> _eventManagers;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WebHookEventManager"/> class.
        /// </summary>
        /// <param name="events">An instance of <see cref="WebHookEvent"/> to trigger events.</param>
        public WebHookEventManager(WebHookEvent events)
        {
            _events = events;

            _eventManagers = new Dictionary<string, Action<string>>
            {
                { WebhookEventTypes.ChatMessageSent, ManageChatMessageSent },
                { WebhookEventTypes.ChannelFollowed, ManageChannelFollowed },
                { WebhookEventTypes.ChannelSubscriptionRenewal, ManageChannelSubscriptionRenewal },
                { WebhookEventTypes.ChannelGiftedSubscription, ManageChannelGiftedSubscription },
                { WebhookEventTypes.ChannelNewSubscription, ManageChannelNewSubscription },
                { WebhookEventTypes.LivestreamStatusUpdated, ManageLivestreamStatusUpdated }
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Manage an incoming event by invoking the appropriate handler based on the event type.
        /// </summary>
        /// <param name="eventType">The type of the event to Manage.</param>
        /// <param name="body">The JSON payload representing the event's data.</param>
        public void ManageEvent(string eventType, string body)
        {
            if (_eventManagers.TryGetValue(eventType, out Action<string> value))
                value(body);
        }

        #endregion

        #region Handlers

        /// <summary>
        /// Manage the "chat.message.sent" event and triggers the corresponding event in <see cref="WebHookEvent"/>.
        /// </summary>
        /// <param name="body">The JSON payload of the event.</param>
        internal void ManageChatMessageSent(string body)
        {
            var chatMessageSent = JsonSerializer.Deserialize<ChatMessageSentPayload>(body);
            _events.TriggerChatMessageSent(new ChatMessageSentEventArgs(chatMessageSent));
        }

        /// <summary>
        /// Manage the "channel.followed" event and triggers the corresponding event in <see cref="WebHookEvent"/>.
        /// </summary>
        /// <param name="body">The JSON payload of the event.</param>
        private void ManageChannelFollowed(string body)
        {
            var channelFollowed = JsonSerializer.Deserialize<ChannelFollowedPayload>(body);
            _events.TriggerChannelFollowed(new ChannelFollowedEventArgs(channelFollowed));
        }

        /// <summary>
        /// Manage the "channel.subscription.renewal" event and triggers the corresponding event in <see cref="WebHookEvent"/>.
        /// </summary>
        /// <param name="body">The JSON payload of the event.</param>
        private void ManageChannelSubscriptionRenewal(string body)
        {
            var channelSubscriptionRenewal = JsonSerializer.Deserialize<ChannelSubscriptionRenewalPayload>(body);
            _events.TriggerChannelSubscriptionRenewal(new ChannelSubscriptionRenewalEventArgs(channelSubscriptionRenewal));
        }

        /// <summary>
        /// Manage the "channel.subscription.gifts" event and triggers the corresponding event in <see cref="WebHookEvent"/>.
        /// </summary>
        /// <param name="body">The JSON payload of the event.</param>
        private void ManageChannelGiftedSubscription(string body)
        {
            var channelGiftedSubscription = JsonSerializer.Deserialize<ChannelSubscriptionGiftsPayload>(body);
            _events.TriggerChannelGiftedSubscription(new ChannelGiftedSubscriptionEventArgs(channelGiftedSubscription));
        }

        /// <summary>
        /// Manage the "channel.subscription.new" event and triggers the corresponding event in <see cref="WebHookEvent"/>.
        /// </summary>
        /// <param name="body">The JSON payload of the event.</param>
        private void ManageChannelNewSubscription(string body)
        {
            var channelNewSubscription = JsonSerializer.Deserialize<ChannelSubscriptionNewPayload>(body);
            _events.TriggerChannelNewSubscription(new ChannelNewSubscriptionEventArgs(channelNewSubscription));
        }

        /// <summary>
        /// Manage the "livestream.status.updated" event and triggers the corresponding event in <see cref="WebHookEvent"/>.
        /// </summary>
        /// <param name="body">The JSON payload of the event.</param>
        private void ManageLivestreamStatusUpdated(string body)
        {
            var livestreamStatusUpdated = JsonSerializer.Deserialize<LivestreamStatusUpdatedPayload>(body);
            _events.TriggerLivestreamStatusUpdated(new LivestreamStatusUpdatedEventArgs(livestreamStatusUpdated));
        }

        #endregion

        
    }
}
