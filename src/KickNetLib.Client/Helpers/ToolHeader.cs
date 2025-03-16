
using System.Net;
using System.Globalization;

using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;

using KickNetLib.Client.Models;

namespace KickNetLib.Client.Helpers
{
    /// <summary>
    /// Utility class for handling Kick webhook headers.
    /// Provides methods for validating and parsing Kick-specific headers in incoming HTTP requests.
    /// </summary>
    public static class ToolHeader
    {
        #region Members

        /// <summary>
        /// The header name for specifying the Kick event type.
        /// </summary>
        public const string HeaderKickEventType = "Kick-Event-Type";

        /// <summary>
        /// The header name for specifying the Kick event version.  
        /// </summary>
        public const string HeaderKickEventVersion = "Kick-Event-Version";

        /// <summary>
        /// The header name for specifying the timestamp of the event message.
        /// </summary>
        public const string HeaderKickEventMessageTimestamp = "Kick-Event-Message-Timestamp";

        /// <summary>
        /// The header name for the Kick event's message signature for validation.
        /// </summary>
        public const string HeaderKickEventSignature = "Kick-Event-Signature";

        /// <summary>
        /// The header name for the subscription ID associated with the event.
        /// </summary>
        public const string HeaderKickEventSuscriptionId = "Kick-Event-Subscription-Id";

        /// <summary>
        /// The header name for the unique message ID of the event.
        /// </summary>
        public const string HeaderKickEventMessageId = "Kick-Event-Message-Id";

        #endregion

        #region Methods

        /// <summary>
        /// Checks if all required Kick event headers are present in the HTTP context.
        /// </summary>
        /// <param name="context">The HttpContext containing the headers to check.</param>
        /// <returns>Returns true if all necessary headers are present, otherwise false.</returns>
        public static bool CheckHeaders(HttpContext context)
        {
            return context.Request.Headers.ContainsKey(HeaderKickEventType)
                   && context.Request.Headers.ContainsKey(HeaderKickEventVersion)
                   && context.Request.Headers.ContainsKey(HeaderKickEventMessageTimestamp)
                   && context.Request.Headers.ContainsKey(HeaderKickEventSignature)
                   && context.Request.Headers.ContainsKey(HeaderKickEventSuscriptionId)
                   && context.Request.Headers.ContainsKey(HeaderKickEventMessageId);
        }

        /// <summary>
        /// Checks if all required Kick event headers are present in the HttpListenerContext.
        /// </summary>
        /// <param name="context">The HttpListenerContext containing the headers to check.</param>
        /// <returns>Returns true if all necessary headers are present, otherwise false.</returns>
        public static bool CheckHeaders(HttpListenerContext context)
        {
            return !string.IsNullOrEmpty(context.Request.Headers.Get(HeaderKickEventType))
                && !string.IsNullOrEmpty(context.Request.Headers.Get(HeaderKickEventVersion))
                && !string.IsNullOrEmpty(context.Request.Headers.Get(HeaderKickEventMessageTimestamp))
                && !string.IsNullOrEmpty(context.Request.Headers.Get(HeaderKickEventSignature))
                && !string.IsNullOrEmpty(context.Request.Headers.Get(HeaderKickEventSuscriptionId))
                && !string.IsNullOrEmpty(context.Request.Headers.Get(HeaderKickEventMessageId));
        }

        #endregion

        #region Parse

        /// <summary>
        /// Parses the headers from the HTTP request into a <see cref="WebHookHeader"/> object.
        /// </summary>
        /// <param name="headers">The headers from the HTTP request.</param>
        /// <returns>A <see cref="WebHookHeader"/> instance containing parsed header values.</returns>
        public static WebHookHeader ParseHeaderToObject(IHeaderDictionary headers)
        {
            Ulid kickEventMessageId = Ulid.Empty;
            Ulid kickEventSuscriptionId = Ulid.Empty;
            string kickEvensSignature = string.Empty;
            DateTimeOffset kickEventMessageTimestamp = new();
            string kickEventVersion = string.Empty;
            string kickEventType = string.Empty;

            if (headers.TryGetValue(HeaderKickEventMessageId, out StringValues headerKickEventMessageId))
                kickEventMessageId = Ulid.Parse(headerKickEventMessageId);

            if (headers.TryGetValue(HeaderKickEventSuscriptionId, out StringValues headerKickEventSuscriptionId))
                kickEventSuscriptionId = Ulid.Parse(headerKickEventSuscriptionId);

            if (headers.TryGetValue(HeaderKickEventSignature, out StringValues headerKickEventSignature))
                kickEvensSignature = headerKickEventSignature;

            if (headers.TryGetValue(HeaderKickEventMessageTimestamp, out StringValues headerKickEventMessageTimestamp))
                kickEventMessageTimestamp = DateTimeOffset.ParseExact(
                                                            headerKickEventMessageTimestamp,
                                                            "yyyy-MM-ddTHH:mm:ssZ",
                                                            CultureInfo.InvariantCulture,
                                                            DateTimeStyles.AssumeUniversal);

            if (headers.TryGetValue(HeaderKickEventVersion, out StringValues headerKickEventVersion))
                kickEventVersion = headerKickEventVersion;

            if (headers.TryGetValue(HeaderKickEventType, out StringValues headerKickEventType))
                kickEventType = headerKickEventType;

            return new WebHookHeader(
                kickEventMessageId,
                kickEventSuscriptionId,
                kickEvensSignature,
                kickEventMessageTimestamp,
                kickEventVersion,
                kickEventType
            );
        }

        #endregion
    }
}
