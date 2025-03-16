
using KickNetLib.Client.Models.Args;

namespace KickNetLib.Client.Webhooks
{
    /// <summary>
    /// The WebHookEvent class defines a set of events and corresponding trigger methods
    /// for handling webhook events in a system. It provides events for various actions
    /// such as chat messages, channel follow, subscription renewals, and livestream status updates.
    /// </summary>
    public class WebHookEvent
    {
        #region Members Events

        /// <summary>
        /// Event triggered when a chat message is sent.
        /// </summary>
        public event EventHandler<ChatMessageSentEventArgs> OnChatMessageSent;
        /// <summary>
        /// Event triggered when a channel is followed.
        /// </summary>
        public event EventHandler<ChannelFollowedEventArgs> OnChannelFollowed;
        /// <summary>
        /// Event triggered when a channel's subscription is renewed.
        /// </summary>
        public event EventHandler<ChannelSubscriptionRenewalEventArgs> OnChannelSubscriptionRenewal;
        /// <summary>
        /// Event triggered when a channel receives a gifted subscription.
        /// </summary>
        public event EventHandler<ChannelGiftedSubscriptionEventArgs> OnChannelGiftedSubscription;
        /// <summary>
        /// Event triggered when a channel gets a new subscription.
        /// </summary>
        public event EventHandler<ChannelNewSubscriptionEventArgs> OnChannelNewSubscription;
        /// <summary>
        /// Event triggered when a livestream's status is updated.
        /// </summary>
        public event EventHandler<LivestreamStatusUpdatedEventArgs> OnLivestreamStatusUpdated;

        #endregion

        #region Triggers

        /// <summary>
        /// Triggers the <see cref="OnChatMessageSent"/> event.
        /// </summary>
        /// <param name="e">The event arguments containing details about the chat message sent.</param>
        internal void TriggerChatMessageSent(ChatMessageSentEventArgs e) =>
           OnChatMessageSent?.Invoke(this, e);

        /// <summary>
        /// Triggers the <see cref="OnChannelFollowed"/> event.
        /// </summary>
        /// <param name="e">The event arguments containing details about the followed channel.</param>
        internal void TriggerChannelFollowed(ChannelFollowedEventArgs e) =>
            OnChannelFollowed?.Invoke(this, e);

        /// <summary>
        /// Triggers the <see cref="OnChannelSubscriptionRenewal"/> event.
        /// </summary>
        /// <param name="e">The event arguments containing details about the subscription renewal.</param>
        internal void TriggerChannelSubscriptionRenewal(ChannelSubscriptionRenewalEventArgs e) => 
            OnChannelSubscriptionRenewal?.Invoke(this, e);

        /// <summary>
        /// Triggers the <see cref="OnChannelGiftedSubscription"/> event.
        /// </summary>
        /// <param name="e">The event arguments containing details about the gifted subscription.</param>
        internal void TriggerChannelGiftedSubscription(ChannelGiftedSubscriptionEventArgs e) => 
            OnChannelGiftedSubscription?.Invoke(this, e);

        /// <summary>
        /// Triggers the <see cref="OnChannelNewSubscription"/> event.
        /// </summary>
        /// <param name="e">The event arguments containing details about the new subscription.</param>
        internal void TriggerChannelNewSubscription(ChannelNewSubscriptionEventArgs e) =>
            OnChannelNewSubscription?.Invoke(this, e);

        /// <summary>
        /// Triggers the <see cref="OnLivestreamStatusUpdated"/> event.
        /// </summary>
        /// <param name="e">The event arguments containing details about the updated livestream status.</param>
        internal void TriggerLivestreamStatusUpdated(LivestreamStatusUpdatedEventArgs e) => 
            OnLivestreamStatusUpdated?.Invoke(this, e);

        #endregion
    }
}
