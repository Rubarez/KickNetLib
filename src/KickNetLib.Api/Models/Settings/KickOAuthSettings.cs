
namespace KickNetLib.Api.Models.Settings
{
    /// <summary>
    /// Represents the OAuth settings for Kick API authentication.
    /// Contains configuration options required for OAuth flows, such as authorization,
    /// token management, and client credentials.
    /// </summary>
    public record KickOAuthSettings
    {
        /// <summary>
        /// Gets the base URL for the Kick OAuth service.
        /// </summary>
        public string BaseUrl { get; init; }

        /// <summary>
        /// Gets the URL for the authorization endpoint used to initiate the OAuth authorization flow.
        /// </summary>
        public string AuthorizationEndpointPath { get; init; }

        /// <summary>
        /// Gets the URL for the token endpoint used to exchange authorization codes for access tokens.
        /// </summary>
        public string TokenEndpointPath { get; init; }

        /// <summary>
        /// Gets the URL for the revoke endpoint used to revoke access tokens.
        /// </summary>
        public string RevokeEndpointTokenPath { get; init; }

        /// <summary>
        /// Gets the client ID used for OAuth authentication with the Kick API.
        /// This is provided when registering your application with the Kick platform.
        /// </summary>
        public string ClientID { get; init; }

        /// <summary>
        /// Gets the client secret used for OAuth authentication with the Kick API.
        /// This is provided when registering your application with the Kick platform.
        /// </summary>
        public string ClientSecret { get; init; }

        /// <summary>
        /// Gets the redirect URI used during the OAuth authorization flow.
        /// This is the URI that the OAuth service redirects to after the user authorizes or denies access.
        /// </summary>
        public string RedirectUri { get; init; }

        /// <summary>
        /// Gets the collection of OAuth scopes required by the application.
        /// Scopes define the permissions the application is requesting from the user.
        /// </summary>
        public ICollection<string> Scopes { get; init; }
    }
}
