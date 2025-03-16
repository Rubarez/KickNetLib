
using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.Core;
using KickNetLib.Api.ApiClients.V1.Categories.Models;
using KickNetLib.Api.Models.Settings;

namespace KickNetLib.Api.ApiClients
{
    /// <summary>
    /// Client for interacting with the categories-related API endpoints in the Kick API.
    /// Inherits from BaseApiClient to provide common HTTP request functionality.
    /// </summary>
    public class CategoryApiClient : BaseApiClient
    {
        #region Members

        /// <summary>
        /// The resource path for categories.
        /// </summary>
        private const string UrlResourcePath = "categories";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CategoryApiClient class.
        /// </summary>
        /// <param name="logger">Logger for logging requests and responses.</param>
        /// <param name="kickSettings">Settings for Kick API configuration, such as access token and base URL.</param>
        public CategoryApiClient(ILogger logger, KickApiSettings kickSettings) : base(logger, kickSettings) { }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Retrieves a list of categories matching a search keyword.
        /// </summary>
        /// <param name="searchKeyword">The search keyword to filter categories.</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A list of categories that match the search keyword.</returns>
        /// <exception cref="ArgumentException">Thrown if the search keyword is null or empty.</exception>
        public async Task<List<Category>> GetCategoriesAsync(string searchKeyword, string accessToken = null)
        {
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                throw new ArgumentException("Search keyword cannot be null or empty.", nameof(searchKeyword));
            }

            var queryParams = new List<KeyValuePair<string, string>>()
            {
                new("q", searchKeyword)
            };

            return await GetAsync<List<Category>>(
                UrlResourcePath,
                ApiVersion.V1,
                queryParams,
                accessToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="idCategory">The ID of the category to retrieve.</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>The category with the specified ID.</returns>
        /// <exception cref="ArgumentException">Thrown if the category ID is less than or equal to zero.</exception>
        public async Task<Category> GetCategoryByIdAsync(int idCategory, string accessToken = null)
        {
            if (idCategory <= 0)
            {
                throw new ArgumentException("Category ID must be greater than zero.", nameof(idCategory));
            }

            var url = $"{UrlResourcePath}/{idCategory}";

            return await GetAsync<Category>(url, ApiVersion.V1, null, accessToken).ConfigureAwait(false);
        }

        #endregion
    }
}
