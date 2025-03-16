
using System.Text.Json.Serialization;

namespace KickNetLib.Client.Models.Payloads.Core
{
    /// <summary>
    /// Represents a position with a start and end point, typically used in context with an emote's location
    /// or other positional data on the Kick platform.
    /// </summary>
    public partial class Position
    {
        /// <summary>
        /// Gets or sets the start position.
        /// This value represents the starting point of a range or position.
        /// </summary>
        [JsonPropertyName("s")]
        public long S { get; set; }

        /// <summary>
        /// Gets or sets the end position.
        /// This value represents the endpoint of a range or position.
        /// </summary>
        [JsonPropertyName("e")]
        public long E { get; set; }
    }
}
