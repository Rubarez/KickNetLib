
using KickNetLib.Client.Models.Payloads;

namespace KickNetLib.Client.Models.Args
{
    /// <summary>
    /// Represents the event arguments for when a chat message is sent.
    /// This class wraps the payload data for a chat-message-sent event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ChatMessageSentEventArgs"/> class.
    /// </remarks>
    /// <param name="data">The payload data for the chat-message-sent event.</param>
    public class ChatMessageSentEventArgs(ChatMessageSentPayload data)
    {
        /// <summary>
        /// Gets the payload data associated with the chat-message-sent event.
        /// </summary>
        public ChatMessageSentPayload Data { get; } = data;
    }
}
