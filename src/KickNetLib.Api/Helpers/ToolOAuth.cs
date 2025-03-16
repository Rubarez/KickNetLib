
using System.Security.Cryptography;
using System.Text;

namespace KickNetLib.Api.Helpers
{
    /// <summary>
    /// A helper class for generating PKCE (Proof Key for Code Exchange) codes, used in OAuth 2.0 authorization flows.
    /// This class helps in generating a code verifier and code challenge to securely exchange tokens.
    /// </summary>
    public static class ToolOAuth
    {
        // Step 1: Generate PKCE code
        /// <summary>
        /// Generates both the code verifier and code challenge as part of the PKCE flow.
        /// </summary>
        /// <returns>A tuple containing the code verifier and code challenge.</returns>
        public static (string CodeVerifier, string CodeChallenge) GeneratePkceCode()
        {
            var codeVerifier = GenerateCodeVerifier();
            var codeChallenge = GenerateCodeChallenge(codeVerifier);
            return (codeVerifier, codeChallenge);
        }

        // Generate a random code verifier (32 bytes base64 URL-safe encoded)
        /// <summary>
        /// Generates a random code verifier, which is a 32-byte URL-safe base64 encoded string.
        /// The code verifier is used in the PKCE flow to securely verify the client.
        /// </summary>
        /// <returns>The generated code verifier as a string.</returns>
        public static string GenerateCodeVerifier()
        {
            // Define the length of the byte array (32 bytes)
            byte[] randomBytes = new byte[32];  // 32 bytes = 256 bits

            // Generate random bytes using RandomNumberGenerator
            RandomNumberGenerator.Fill(randomBytes);

            // Return the base64 URL-safe encoded string
            return Base64UrlEncode(randomBytes);
        }

        // Generate a code challenge using SHA256 hash of the code verifier
        /// <summary>
        /// Generates a code challenge by performing a SHA256 hash of the code verifier.
        /// The code challenge is used to ensure the integrity of the code verifier during the authorization process.
        /// </summary>
        /// <param name="codeVerifier">The code verifier generated earlier.</param>
        /// <returns>The generated code challenge as a base64 URL-safe encoded string.</returns>
        public static string GenerateCodeChallenge(string codeVerifier)
        {
            using (var sha256 = SHA256.Create())
            {
                var codeVerifierBytes = Encoding.UTF8.GetBytes(codeVerifier);
                var hash = sha256.ComputeHash(codeVerifierBytes);

                // Return the base64 URL-safe encoded SHA256 hash as the code challenge
                return Base64UrlEncode(hash);
            }
        }

        // Base64 URL encoding (RFC 4648)
        /// <summary>
        /// Encodes a byte array into a base64 URL-safe string as per RFC 4648.
        /// </summary>
        /// <param name="input">The byte array to be encoded.</param>
        /// <returns>A base64 URL-safe encoded string.</returns>
        public static string Base64UrlEncode(byte[] input)
        {
            // Perform standard base64 encoding
            var base64 = Convert.ToBase64String(input);

            // Remove padding (=) characters
            base64 = base64.Split('=')[0];

            // Replace characters to make the encoding URL-safe
            base64 = base64.Replace('+', '-').Replace('/', '_');

            return base64;
        }
    }
}
