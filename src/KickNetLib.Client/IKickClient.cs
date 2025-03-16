
using KickNetLib.Client.Webhooks;

namespace KickNetLib.Client
{
    /// <summary>
    /// Interface for interacting with the KickClient, providing access to the WebHookReceiver instance.
    /// </summary>
    public interface IKickClient
    {
        #region Properties

        /// <summary>
        /// Gets the WebHookReceiver instance for handling webhook events.
        /// </summary>
        WebHookReceiver WebHook { get; }

        #endregion
    }
}