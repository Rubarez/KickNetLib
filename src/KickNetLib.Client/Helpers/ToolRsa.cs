
using System.Text;
using System.Security.Cryptography;

namespace KickNetLib.Client.Helpers
{
    /// <summary>
    /// A utility class that provides RSA-related helper methods for working with public keys and signature verification.
    /// </summary>
    public class ToolRsa
    {
        /// <summary>
        /// Parses a PEM-encoded public key and converts it into an RSAParameters structure that can be used for cryptographic operations.
        /// </summary>
        /// <param name="pemData">The PEM-encoded public key data as a byte array.</param>
        /// <returns>An RSAParameters object containing the parsed public key.</returns>
        /// <exception cref="Exception">Thrown if the PEM string is not in a valid public key format.</exception>
        public static RSAParameters ParsePublicKey(byte[] pemData)
        {
            string pemString = Encoding.UTF8.GetString(pemData);
            if (pemString.Contains("-----BEGIN PUBLIC KEY-----") && pemString.Contains("-----END PUBLIC KEY-----"))
            {
                pemString = pemString.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Trim();
                byte[] rawData = Convert.FromBase64String(pemString);
                using (var rsa = RSA.Create())
                {
                    rsa.ImportSubjectPublicKeyInfo(rawData, out _);
                    return rsa.ExportParameters(false);
                }
            }
            else
            {
                throw new Exception("Invalid public key format");
            }
        }

        /// <summary>
        /// Verifies that the given body data has been signed correctly by the provided RSA public key and signature.
        /// </summary>
        /// <param name="publicKey">The RSAParameters object containing the public key used to verify the signature.</param>
        /// <param name="body">The body (message) data that was signed.</param>
        /// <param name="signature">The base64-encoded signature to verify.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public static bool Verify(RSAParameters publicKey, byte[] body, string signature)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);

                // Decode the Base64 signature
                byte[] decodedSignature = Convert.FromBase64String(signature);

                // Hash the body with SHA256
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(body);

                    try
                    {
                        // Verify the RSA signature using PKCS1 v1.5 and SHA256
                        return rsa.VerifyData(body, decodedSignature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
    }
}
