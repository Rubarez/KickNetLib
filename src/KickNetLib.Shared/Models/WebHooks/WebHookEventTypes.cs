namespace KickNetLib.Shared.Models.WebHooks
{
    /// <summary>
    /// Contains constants for different webhook event types.
    /// These event types are used to identify specific events that can be triggered
    /// in the system and will be handled by webhook subscribers.
    /// </summary>
    public static class WebhookEventTypes
    {
        /// <summary>
        /// Event triggered when a chat message is sent.
        /// </summary>
        public const string ChatMessageSent = "chat.message.sent";

        /// <summary>
        /// Event triggered when a user follows a channel.
        /// </summary>
        public const string ChannelFollowed = "channel.followed";

        /// <summary>
        /// Event triggered when a channel's subscription is renewed.
        /// </summary>
        public const string ChannelSubscriptionRenewal = "channel.subscription.renewal";

        /// <summary>
        /// Event triggered when a user gifts a subscription to a channel.
        /// </summary>
        public const string ChannelGiftedSubscription = "channel.subscription.gifts";

        /// <summary>
        /// Event triggered when a user subscribes to a channel.
        /// </summary>
        public const string ChannelNewSubscription = "channel.subscription.new";

        /// <summary>
        /// Event triggered when the livestream status is updated.
        /// </summary>
        public const string LivestreamStatusUpdated = "livestream.status.updated";
    }
}
