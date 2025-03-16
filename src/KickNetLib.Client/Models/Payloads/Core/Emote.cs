
using System.Text.Json.Serialization;

namespace KickNetLib.Client.Models.Payloads.Core
{
    /// <summary>
    /// Represents an emote used in the Kick platform.
    /// Contains the emote's unique identifier and its positions in a given context.
    /// </summary>
    public partial class Emote
    {
        /// <summary>
        /// Gets or sets the unique identifier for the emote.
        /// This is used to reference the emote in the Kick platform.
        /// </summary>
        [JsonPropertyName("emote_id")]
        public string EmoteId { get; set; }

        /// <summary>
        /// Gets or sets the list of positions associated with the emote.
        /// These positions represent where and how the emote is used, such as in chat or messages.
        /// </summary>
        [JsonPropertyName("positions")]
        public List<Position> Positions { get; set; }
    }
}
