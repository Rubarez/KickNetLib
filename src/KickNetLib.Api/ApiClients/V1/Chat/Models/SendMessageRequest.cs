
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.Chat.Models
{
    /// <summary>
    /// Represents a request to send a message in a chat.
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessageRequest"/> class.
        /// </summary>
        /// <param name="content">The content of the message to be sent.</param>
        /// <param name="type">The type of the message (either user or bot).</param>
        public SendMessageRequest(string content, MessageType type)
        {
            Content = content;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the broadcaster's user ID (optional).
        /// Used when the message is sent by a broadcaster.
        /// </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public int? BroadcasterId { get; set; }

        /// <summary>
        /// Gets the content of the message to be sent.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; }

        /// <summary>
        /// Gets the type of the message.
        /// This value indicates whether the message is from a user or a bot.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType Type { get; }
    }
}
