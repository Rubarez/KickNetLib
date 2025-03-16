
using System.Text.Json.Serialization;

namespace KickNetLib.Api.ApiClients.V1.Users.Models
{
    /// <summary>
    /// Represents a user in the system with relevant profile information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        /// <remarks>
        /// This property contains the email associated with the user account.
        /// </remarks>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <remarks>
        /// This is the display name of the user that is used in the platform.
        /// </remarks>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL to the profile picture of the user.
        /// </summary>
        /// <remarks>
        /// This property contains the link to the user's profile picture, which can be displayed in the UI.
        /// </remarks>
        [JsonPropertyName("profile_picture")]
        public string ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the unique user ID.
        /// </summary>
        /// <remarks>
        /// This is a unique identifier for the user in the system.
        /// </remarks>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}
