
using Microsoft.Extensions.Logging;

using KickNetLib.Client.Webhooks;

namespace KickNetLib.Client
{
    /// <summary>
    /// Represents the KickClient that interacts with the Kick platform and handles webhooks.
    /// </summary>
    public class KickClient : IKickClient
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KickClient"/> class.
        /// </summary>
        /// <param name="logger">The logger instance to be used for logging, or null to use the default logger. If null, a default logger will be created automatically.</param>
        /// <param name="validateSender">A flag indicating whether the sender of webhook requests should be validated. Defaults to <c>true</c>.</param>
        /// <param name="PublicKeyPem">An optional PEM-formatted public key to be used for validating webhook sender signatures. If not provided, a default key will be used.</param>
        public KickClient(ILogger<KickClient> logger = null,
                          bool validateSender = true,
                          string PublicKeyPem = null)
        {
            logger ??= CreateDefaultLogger();

            WebHook = new WebHookReceiver(logger, validateSender, PublicKeyPem);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates a default logger when none is provided.
        /// </summary>
        /// <returns>The default logger for KickClient.</returns>
        private static ILogger<KickClient> CreateDefaultLogger()
        {
            return LoggerFactory.Create(builder => builder.AddConsole())
                .CreateLogger<KickClient>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the WebHookReceiver instance that handles webhook events.
        /// </summary>
        public WebHookReceiver WebHook { get; }

        #endregion
    }
}
