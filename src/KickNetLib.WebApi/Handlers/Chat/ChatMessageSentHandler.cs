
using KickNetLib.Client.Models.Args;

namespace KickNetLib.WebApi.Handlers.Chat
{
    /// <summary>
    /// Handles the event when a chat message is sent.
    /// </summary>
    public class ChatMessageSentHandler
    {
        private readonly ILogger<ChatMessageSentHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessageSentHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging information during the event handling.</param>
        public ChatMessageSentHandler(ILogger<ChatMessageSentHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the chat message sent event by logging the event data.
        /// </summary>
        /// <param name="sender">The object that triggered the event. Can be null if not applicable.</param>
        /// <param name="e">Event arguments containing the data related to the sent chat message.</param>
        public void Handle(object sender, ChatMessageSentEventArgs e)
        {
            // Logs the event data when a chat message is sent.
            _logger.LogInformation("OnChatMessageSent: {@data}", e.Data);
        }
    }
}
