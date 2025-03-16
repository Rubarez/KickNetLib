
using System.Text.Json.Serialization;

namespace KickNetLib.Api.Models.ApiClients
{
    /// <summary>
    /// A generic wrapper class used to standardize API responses.
    /// It contains the actual data returned from the API along with an optional message.
    /// </summary>
    /// <typeparam name="TData">The type of the data that will be wrapped in the response.</typeparam>
    public class WrapperResponse<TData>
    {
        /// <summary>
        /// The actual data returned from the API. This is the main content of the response.
        /// </summary>
        [JsonPropertyName("data")]
        public TData Data { get; set; }

        /// <summary>
        /// An optional message that may accompany the response, such as error or success messages.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
