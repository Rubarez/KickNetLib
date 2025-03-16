
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.Chat.Models
{
    /// <summary>
    /// Represents the response received after sending a message in a chat.
    /// </summary>
    public class SendMessageResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the message was successfully sent.
        /// </summary>
        [JsonPropertyName("is_sent")]
        public bool IsSent { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the sent message.
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }
    }
}
