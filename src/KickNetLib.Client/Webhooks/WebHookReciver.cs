
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using KickNetLib.Client.Helpers;
using System.Text;

namespace KickNetLib.Client.Webhooks
{
    /// <summary>
    /// The WebHookReciver class handles the processing of incoming webhooks. It validates headers,
    /// reads the request body, and forwards the event data to an event handler for processing.
    /// </summary>
    public class WebHookReceiver
    {
        #region Members

        private readonly ILogger _logger;
        private readonly WebHookEvent _events;
        private readonly WebHookEventManager _eventHandler;
        private readonly bool _validateSender;
        private readonly string _publicKeyPem;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WebHookReceiver"/> class.
        /// </summary>
        /// <param name="logger">An instance of <see cref="ILogger"/> used for logging errors, events, and other relevant information.</param>
        /// <param name="validateSender">A flag indicating whether the sender of incoming webhooks should be validated. Defaults to <c>true</c>.</param>
        /// <param name="PublicKeyPem">An optional PEM-formatted public key used for validating the sender's signature. If not provided, a default key will be used.</param>
        public WebHookReceiver(ILogger logger, bool validateSender, string PublicKeyPem = null)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _validateSender = validateSender;
            _publicKeyPem = PublicKeyPem;

            _events = new WebHookEvent();
            _eventHandler = new WebHookEventManager(_events);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the incoming webhook request, processes the request body, 
        /// and validates the headers to ensure its authenticity. 
        /// If the webhook is valid, the event data is forwarded to the appropriate event handler 
        /// for further processing.
        /// </summary>
        /// <param name="context">The HTTP context representing the incoming request, including headers and body.</param>
        /// <param name="publicKeyPem">An optional PEM-formatted public key used to validate the signature of the request. 
        /// If not provided, a default key will be used.</param>
        /// <returns>A task representing the asynchronous operation of processing the webhook request.</returns>
        /// <exception cref="Exception">Thrown if an error occurs during the validation or processing of the webhook request.</exception>
        public async Task ReciveWebHook(HttpContext context, string publicKeyPem = null) 
        {
            try
            {
                _logger.LogDebug("Details of the request: {@context}", context);

                // Check if headers of kick are present
                if (!ToolHeader.CheckHeaders(context))
                {
                    _logger.LogError("All required headers not are present");
                    return;
                }

                var headers = ToolHeader.ParseHeaderToObject(context.Request.Headers);

                var body = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();

                if (_validateSender)
                {
                    if (publicKeyPem is null && !string.IsNullOrEmpty(_publicKeyPem))
                        publicKeyPem = _publicKeyPem;

                    _logger.LogDebug("PublicKeyPem Provided (If nothing loads a default): {@publicKeyPem}", publicKeyPem);

                    // Validate if the webhook is sended by Kick
                    bool isSendedByKick = ToolValidation.ValidateSender(headers, body, publicKeyPem);
                    if (!isSendedByKick)
                    {
                        _logger.LogWarning("Recived a webhook not sended by Kick");
                        return;
                    }
                }

                var kickEventType = context.Request.Headers[ToolHeader.HeaderKickEventType];

                _eventHandler.ManageEvent(kickEventType, body);
                _logger.LogInformation("Webhook processed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error handling webhook: {@error}", ex.Message);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="WebHookEvent"/> associated with this receiver.
        /// </summary>
        public WebHookEvent Events => _events;

        #endregion
    }
}
