
using System.Text.Json.Serialization;

namespace KickNetLib.Client.Models.Payloads.Core
{
    public partial class KickUser
    {
        /// <summary>
        /// Gets or sets a value indicating whether the user is anonymous.
        /// If true, the user is anonymous, and their identity is not disclosed.
        /// </summary>
        [JsonPropertyName("is_anonymous")]
        public bool IsAnonymous { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// This ID is used to identify the user within the Kick platform.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// This is the public name displayed for the user on the Kick platform.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is verified.
        /// If true, the user has been verified by Kick and their account is validated.
        /// </summary>
        [JsonPropertyName("is_verified")]
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the profile picture URL of the user.
        /// This is the URI pointing to the user's profile image.
        /// </summary>
        [JsonPropertyName("profile_picture")]
        public Uri ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the channel slug associated with the user.
        /// The slug represents a part of the URL used for the user's channel on the Kick platform.
        /// </summary>
        [JsonPropertyName("channel_slug")]
        public string ChannelSlug { get; set; }
    }
}
