using System.Text;
using System.Web;
using System.Diagnostics;

using System.Text.Json;

using KickNetLib.Api.Models.Settings;
using KickNetLib.Api.Helpers;
using static System.Formats.Asn1.AsnWriter;

namespace KickNetLib.Api.Auth
{
    /// <summary>
    /// Client for interacting with Kick OAuth authorization and token exchange endpoints.
    /// Provides methods for authorization, token exchange, refresh, and revocation.
    /// </summary>
    public class KickOAuthClient
    {
        #region Members

        private readonly KickOAuthSettings _kickOAuthSettings;
        private readonly HttpClient _httpClient;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KickOAuthClient"/> class.
        /// </summary>
        /// <param name="kickOAuthSettings">OAuth settings required for authorization and token exchange.</param>
        public KickOAuthClient(KickOAuthSettings kickOAuthSettings)
        {
            _kickOAuthSettings = kickOAuthSettings;
            _httpClient = new HttpClient();
        }

        #endregion

        #region Methods Authorization Endpoint

        /// <summary>
        /// Starts the OAuth authorization process by generating a PKCE code challenge,
        /// constructing the authorization URL, and launching the default browser for the user to authorize.
        /// </summary>
        public void ProcessAuthorization(List<string> scopes = null)
        {
            CheckGuards();

            // Generate PKCE code verifier and code challenge
            var (CodeVerifier, CodeChallenge) = ToolOAuth.GeneratePkceCode();
            string codeVerifier = CodeVerifier;
            string codeChallenge = CodeChallenge;

            // Build authorization URL
            string authorizationUrl = GenerateAuthorizationURL(codeChallenge, codeVerifier, scopes).ToString();

            // If you want manually scopes
            // string authorizationUrl = GenerateAuthorizationURL(codeChallenge, codeVerifier, "user:read channel:read").ToString();

            // Launch default browser
            Process.Start(new ProcessStartInfo(authorizationUrl) { UseShellExecute = true });
        }

        #endregion

        #region Methods Token Endpoint Token
        /// <summary>
        /// Exchanges the provided authorization code and code verifier for an OAuth access token.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the user after successful authorization.</param>
        /// <param name="codeVerifier">The code verifier used in the authorization process to enhance security.</param>
        /// <returns>A <see cref="KickOAuthTokenResponse"/> containing the access token, refresh token (if available), and other related data.</returns>
        public KickOAuthTokenResponse ExchangeAuthCodeForAccessToken(string authorizationCode, string codeVerifier)
        {
            CheckGuards();

            // Exchange authorization code for access token
            var tokenEndpoint = $"{ _kickOAuthSettings.BaseUrl }{ _kickOAuthSettings.TokenEndpointPath}";

            var tokenRequestContent = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("client_id", _kickOAuthSettings.ClientID),
                new KeyValuePair<string, string>("client_secret", _kickOAuthSettings.ClientSecret),
                new KeyValuePair<string, string>("redirect_uri", _kickOAuthSettings.RedirectUri),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code_verifier", codeVerifier)
            ]);

            var response = _httpClient.PostAsync(tokenEndpoint, tokenRequestContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<KickOAuthTokenResponse>(content);
            }

            return null;
        }

        #endregion

        #region Methods Token Endpoint Refresh

        /// <summary>
        /// Exchanges a refresh token for a new access token.
        /// </summary>
        /// <param name="refreshToken">The refresh token used to get a new access token.</param>
        /// <returns>The new OAuth token response containing the refreshed access token.</returns>
        public KickOAuthTokenResponse ExchangeTokenFromRefreshToken(string refreshToken)
        {
            CheckGuards();

            ArgumentException.ThrowIfNullOrEmpty(refreshToken);

            // Exchange authorization code for access token
            var refreshTokenEndpoint = $"{_kickOAuthSettings.BaseUrl}{_kickOAuthSettings.TokenEndpointPath}";

            var tokenRequestContent = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("refresh_token", refreshToken),
                new KeyValuePair<string, string>("client_id", _kickOAuthSettings.ClientID),
                new KeyValuePair<string, string>("client_secret", _kickOAuthSettings.ClientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
            ]);

            var response = _httpClient.PostAsync(refreshTokenEndpoint, tokenRequestContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<KickOAuthTokenResponse>(content);
            }

            return null;
        }

        #endregion

        #region Methods Token Endpoint Revoke

        /// <summary>
        /// Revokes a specified token, either an access token or a refresh token.
        /// </summary>
        /// <param name="token">The token (access or refresh) to revoke.</param>
        /// <param name="tokenType">Specifies whether the provided token is an access token or a refresh token.</param>
        /// <returns>True if the token was successfully revoked; otherwise, false.</returns>
        public bool RevokeToken(string token, TokenType tokenType)
        {
            CheckGuards();

            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("You need provide a refresh token or acccess token");

            string tokenHintType = tokenType switch
            {
                TokenType.RefreshToken => "refresh_token",
                _ => "access_token",
            };

            // Exchange authorization code for access token
            var refreshTokenEndpoint = $"{_kickOAuthSettings.BaseUrl}{_kickOAuthSettings.RevokeEndpointTokenPath}";

            var tokenRequestContent = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("token", token),
                new KeyValuePair<string, string>("token_hint_type", tokenHintType),
            ]);

            var response = _httpClient.PostAsync(refreshTokenEndpoint, tokenRequestContent).Result;

            if (response.IsSuccessStatusCode)
                return true;
           
            return false;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Generates the URL for the authorization endpoint, including support for PKCE (Proof Key for Code Exchange) flow.
        /// </summary>
        /// <param name="codeChallenge">The code challenge generated for the PKCE flow, used to enhance security during the authorization process.</param>
        /// <param name="codeVerifier">The original code verifier associated with the code challenge, used to validate the authorization request.</param>
        /// <param name="scopes">Optional parameter representing the scopes of access requested. If not provided, default scopes may be used.</param>
        /// <returns>The complete authorization URL, including necessary parameters for the authorization flow.</returns>
        private Uri GenerateAuthorizationURL(string codeChallenge, string codeVerifier, List<string> scopes = null)
        {
            string scopesToSent = string.Join(" ", _kickOAuthSettings.Scopes);

            if (scopes is not null)
                scopesToSent = string.Join(" ", scopes);

            var url = new StringBuilder($"{_kickOAuthSettings.BaseUrl}{_kickOAuthSettings.AuthorizationEndpointPath}")
            .Append("?response_type=code")
            .Append("&client_id=").Append(_kickOAuthSettings.ClientID)
            .Append("&redirect_uri=").Append(HttpUtility.UrlEncode(_kickOAuthSettings.RedirectUri))
            .Append("&scope=").Append(HttpUtility.UrlEncode(scopesToSent))
            .Append("&code_challenge=").Append(codeChallenge)
            .Append("&code_challenge_method=S256")
            .Append("&state=").Append(codeVerifier)
            .ToString();

            return new Uri(url);
        }

        #endregion

        #region Guards

        /// <summary>
        /// Checks that all required OAuth settings are provided.
        /// Throws exceptions if any required setting is missing or invalid.
        /// </summary>
        private void CheckGuards()
        {
            ArgumentException.ThrowIfNullOrEmpty(_kickOAuthSettings.ClientID);
            ArgumentException.ThrowIfNullOrEmpty(_kickOAuthSettings.ClientSecret);
            ArgumentException.ThrowIfNullOrEmpty(_kickOAuthSettings.BaseUrl);
            ArgumentException.ThrowIfNullOrEmpty(_kickOAuthSettings.RedirectUri);
            ArgumentException.ThrowIfNullOrEmpty(_kickOAuthSettings.AuthorizationEndpointPath);
            ArgumentException.ThrowIfNullOrEmpty(_kickOAuthSettings.TokenEndpointPath);
            ArgumentException.ThrowIfNullOrEmpty(_kickOAuthSettings.RevokeEndpointTokenPath);

            ArgumentNullException.ThrowIfNull(_kickOAuthSettings.Scopes , nameof(_kickOAuthSettings.Scopes));
            if (_kickOAuthSettings.Scopes.Count == 0)
            {
                throw new ArgumentException("Scopes cannot be empty.", nameof(_kickOAuthSettings.Scopes));
            }
        }

        #endregion
    }
}
