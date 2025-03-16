
namespace KickNetLib.Client.Models.Settings
{
    /// <summary>
    /// Represents the settings for configuring webhook validation.
    /// </summary>
    public class KickWebHookSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the sender of the webhook should be validated.
        /// When set to true, the webhook sender's identity will be checked to ensure it's a trusted source.
        /// </summary>
        public bool ValidateSender { get; set; }

        /// <summary>
        /// Gets or sets the public key in PEM format used for validating the webhook sender.
        /// This key is typically used to verify the signature of the incoming webhook payload.
        /// </summary>
        public string PublicKeyPem { get; set; }
    }
}
