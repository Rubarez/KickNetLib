
using System.Text.Json.Serialization;

using KickNetLib.Client.Models.Payloads.Core;

namespace KickNetLib.Client.Models.Payloads
{
    /// <summary>
    /// Represents the payload data for a chat message sent event.
    /// Contains details about the message, broadcaster, sender, message content, and any emotes used.
    /// </summary>
    public partial class ChatMessageSentPayload
    {
        /// <summary>
        /// Gets or sets the unique identifier for the chat message.
        /// Represents the ID of the sent message.
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the broadcaster's information.
        /// Represents the user who owns the channel where the message was sent.
        /// </summary>
        [JsonPropertyName("broadcaster")]
        public KickUser Broadcaster { get; set; }

        /// <summary>
        /// Gets or sets the sender's information.
        /// Represents the user who sent the message in the chat.
        /// </summary>
        [JsonPropertyName("sender")]
        public KickUser Sender { get; set; }

        /// <summary>
        /// Gets or sets the content of the chat message.
        /// Represents the actual text content of the sent message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the list of emotes used in the chat message.
        /// Represents any emotes (images or animations) that were included in the message content.
        /// </summary>
        [JsonPropertyName("emotes")]
        public List<Emote> Emotes { get; set; }
    }
}
