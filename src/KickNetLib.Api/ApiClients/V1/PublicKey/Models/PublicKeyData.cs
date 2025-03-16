
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.PublicKey.Models
{
    /// <summary>
    /// Represents the data model for a public key.
    /// </summary>
    public class PublicKeyData
    {
        /// <summary>
        /// Gets or sets the public key.
        /// </summary>
        /// <remarks>
        /// This is the key that can be used for verifying data signatures or encryption.
        /// </remarks>
        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; }
    }
}
