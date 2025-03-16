
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.Token.Models
{
    /// <summary>
    /// Represents the introspection result of an OAuth2 token.
    /// </summary>
    public class TokenIntrospect
    {
        /// <summary>
        /// Gets or sets a value indicating whether the token is active.
        /// </summary>
        /// <remarks>
        /// If the token is not active, it should not be used for accessing protected resources.
        /// </remarks>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the client ID associated with the token.
        /// </summary>
        /// <remarks>
        /// This is the identifier for the client that the token is associated with.
        /// </remarks>
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the expiration time of the token in Unix timestamp format.
        /// </summary>
        /// <remarks>
        /// This timestamp represents when the token will expire.
        /// </remarks>
        [JsonPropertyName("exp")]
        public long Exp { get; set; }

        /// <summary>
        /// Gets or sets the scope of access granted by the token.
        /// </summary>
        /// <remarks>
        /// This indicates the permissions or access level that the token grants.
        /// </remarks>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
    }
}
