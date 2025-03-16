
namespace KickNetLib.Api.Models.Settings
{
    /// <summary>
    /// Represents the settings required for configuring access to the Kick API.
    /// This class contains the base URL for the API and the access token used for authentication.
    /// </summary>
    public class KickApiSettings
    {
        /// <summary>
        /// Gets or sets the base URL for the Kick API.
        /// This URL is used as the root address for all API requests.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the access token used for authenticating API requests.
        /// This token is required to authorize access to protected endpoints of the Kick API.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the OAuth settings for the Kick API.
        /// This may contain additional settings required for OAuth authentication, 
        /// such as client ID, client secret, or other OAuth-specific configurations.
        /// </summary>
        public KickOAuthSettings KickOAuthSettings { get; set; }
    }
}
