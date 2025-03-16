
namespace KickNetLib.Api.Models.Core
{
    /// <summary>
    /// A class representing the various authentication schemes supported by the API.
    /// This class contains static readonly fields representing common authentication schemes.
    /// </summary>
    public sealed class ApiAuthenticationScheme
    {
        /// <summary>
        /// Represents the "Bearer" authentication scheme, commonly used for token-based authentication.
        /// </summary>
        public static readonly string Bearer = "Bearer";

        /// <summary>
        /// Represents the "Basic" authentication scheme, where the username and password are sent as base64-encoded strings.
        /// </summary>
        public static readonly string Basic = "Basic";

        /// <summary>
        /// Represents the "Digest" authentication scheme, which involves hashing the credentials for secure transmission.
        /// </summary>
        public static readonly string Digest = "Digest";

        /// <summary>
        /// Represents the "NTLM" authentication scheme, used for Windows-based authentication.
        /// </summary>
        public static readonly string NTLM = "NTLM";
    }
}
