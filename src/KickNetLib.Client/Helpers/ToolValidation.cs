
using System.Security.Cryptography;
using System.Text;

using KickNetLib.Client.Models;

namespace KickNetLib.Client.Helpers
{
    /// <summary>
    /// A static utility class for performing validation operations related to webhooks.
    /// </summary>
    public static class ToolValidation
    {
        /// <summary>
        /// Validates the sender of a webhook request by comparing the provided signature against a public key.
        /// </summary>
        /// <param name="webHookHeader">The header information of the webhook request, which includes event details and the signature for verification.</param>
        /// <param name="body">The raw body content of the webhook request, used to verify the signature.</param>
        /// <param name="publicKeyPem">An optional PEM-formatted public key used for signature verification. If not provided, a default key will be used.</param>
        /// <returns>True if the webhook signature is valid; otherwise, false.</returns>
        public static bool ValidateSender(WebHookHeader webHookHeader, string body, string publicKeyPem = null)
        {
            var publicKeyPemValue = !string.IsNullOrWhiteSpace(publicKeyPem)
            ? publicKeyPem
            : DefaultPublicKeyPem;

            // The signature is created through the concatenation of the following values into a single string, separated by a .
            // Kick - Event - Message - Id
            // Kick - Event - Message - Timestamp
            // The raw body of the request
            string concatenation = $"{webHookHeader.KickEventMessageId}.{webHookHeader.KickEventMessageTimestamp.ToString("yyyy-MM-ddTHH:mm:ssZ")}.{body}";
            
            byte[] signature = Encoding.UTF8.GetBytes(concatenation);

            // Convert PEM string to byte array
            byte[] publicKeyBytes = Encoding.UTF8.GetBytes(publicKeyPemValue);

            // Parse the public key
            RSAParameters publicKey = ToolRsa.ParsePublicKey(publicKeyBytes);

            // Verify the signature
            return ToolRsa.Verify(publicKey, signature, webHookHeader.KickEvensSignature);
        }

        // A constant that holds the default PEM-formatted public key used for signature validation.
        // This key is typically provided by the service sending the webhook.
        private const string DefaultPublicKeyPem = @"-----BEGIN PUBLIC KEY-----
        MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq/+l1WnlRrGSolDMA+A8
        6rAhMbQGmQ2SapVcGM3zq8ANXjnhDWocMqfWcTd95btDydITa10kDvHzw9WQOqp2
        MZI7ZyrfzJuz5nhTPCiJwTwnEtWft7nV14BYRDHvlfqPUaZ+1KR4OCaO/wWIk/rQ
        L/TjY0M70gse8rlBkbo2a8rKhu69RQTRsoaf4DVhDPEeSeI5jVrRDGAMGL3cGuyY
        6CLKGdjVEM78g3JfYOvDU/RvfqD7L89TZ3iN94jrmWdGz34JNlEI5hqK8dd7C5EF
        BEbZ5jgB8s8ReQV8H+MkuffjdAj3ajDDX3DOJMIut1lBrUVD1AaSrGCKHooWoL2e
        twIDAQAB
        -----END PUBLIC KEY-----";

    }
}
