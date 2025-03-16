
using System.Text.Json.Serialization;

namespace KickNetLib.Api.Auth
{
    /// <summary>
    /// Represents the response returned after successfully authenticating with the Kick OAuth service.
    /// This class contains the access token and other related information needed for accessing the API
    /// on behalf of the user.
    /// </summary>
    public class KickOAuthTokenResponse
    {
        /// <summary>
        /// Gets or sets the access token used for authenticating requests to the Kick API.
        /// The access token is passed in the Authorization header of requests.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the expiration time of the access token in seconds.
        /// The token expires after this period, and a new access token must be obtained using the refresh token.
        /// </summary>
        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the refresh token used to obtain a new access token once the current access token expires.
        /// The refresh token typically has a longer lifetime than the access token.
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the scope of the access token, which defines the level of access granted by the token.
        /// This is a space-separated list of scopes that the user has authorized.
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of token returned. Typically, this would be "Bearer" for OAuth 2.0 tokens.
        /// The token type defines how the token is used in the Authorization header.
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}
