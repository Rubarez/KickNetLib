
namespace KickNetLib.Api.Auth
{
    // Enum to represent different types of authentication tokens
    public enum TokenType
    {
        // Represents an access token, typically used to authenticate and access protected resources
        AccessToken,

        // Represents a refresh token, used to obtain a new access token once it expires
        RefreshToken
    }
}
