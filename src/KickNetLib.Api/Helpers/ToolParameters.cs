
using System.Web;

namespace KickNetLib.Api.Helpers
{
    /// <summary>
    /// A utility class to help with building query strings for HTTP requests.
    /// This class is useful when constructing query strings from a list of key-value pairs.
    /// </summary>
    public static class ToolParameters
    {
        /// <summary>
        /// Builds a query string from a list of key-value pairs.
        /// Each key-value pair is URL-encoded to ensure proper formatting in the query string.
        /// </summary>
        /// <param name="queryParams">A list of key-value pairs representing the query parameters.</param>
        /// <returns>A query string with URL-encoded key-value pairs.</returns>
        public static string BuildQueryString(List<KeyValuePair<string, string>> queryParams)
        {
            return string.Join("&", queryParams
                .ConvertAll(p => $"{HttpUtility.UrlEncode(p.Key)}={HttpUtility.UrlEncode(p.Value)}"));
        }
    }
}
