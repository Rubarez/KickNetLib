
namespace KickNetLib.DesktopFormsTool.Models
{
    public class TokenInfo
    {
        public DateTime TokenExpireAt { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string StringTokenExpireAt
        {
            get { return TokenExpireAt.ToString("dd-MM-yyyy HH:mm:ss"); }
        }
    }
}
