using System.Text;
using System.Text.Json;
using System.Net;

using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.ApiClients;
using KickNetLib.Api.Models.Core;
using KickNetLib.Api.Helpers;
using KickNetLib.Api.Models.Settings;
using KickNetLib.Api.Exceptions;
using System.Net.Mime;

namespace KickNetLib.Api.ApiClients
{
    /// <summary>
    /// Base API client for interacting with the Kick API. 
    /// Provides common methods for making HTTP requests (GET, POST, PATCH, DELETE) to the API endpoints.
    /// </summary>
    public abstract class BaseApiClient
    {
        #region Members

        private readonly ILogger _logger; // Logger to log request and response details
        private readonly HttpClient _httpClient; // HTTP client for making requests
        private readonly KickApiSettings _kickApiSettings; // Kick API settings (e.g., access token, base URL)
        private readonly string _BaseUrl = "https://api.kick.com/public/"; // Default API base URL

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiClient"/> class.
        /// </summary>
        /// <param name="logger">Logger for logging request and response details.</param>
        /// <param name="kickSettings">Kick API settings, including access token and base URL.</param>
        protected BaseApiClient(ILogger logger, KickApiSettings kickSettings)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(kickSettings);

            _logger = logger;
            _kickApiSettings = kickSettings;

            // Set custom base URL if provided in settings
            if (!string.IsNullOrEmpty(_kickApiSettings.BaseUrl))
                _BaseUrl = _kickApiSettings.BaseUrl;

            _httpClient = new HttpClient(); // Initialize HttpClient for making requests
        }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Sends a GET request to the API and returns the deserialized data.
        /// </summary>
        /// <typeparam name="TData">The type of data expected in the response.</typeparam>
        /// <param name="urlResourcePath">The relative URL path for the resource.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="queryParams">Optional query parameters for the request.</param>
        /// <param name="accessToken">Optional access token for authorization.</param>
        /// <returns>Deserialized data from the response.</returns>
        protected async Task<TData> GetAsync<TData>(
            string urlResourcePath,
            ApiVersion apiVersion,
            List<KeyValuePair<string, string>> queryParams = null,
            string accessToken = null)
            where TData : class, new()
        {
            ArgumentException.ThrowIfNullOrEmpty(urlResourcePath); // Ensure the URL resource path is provided

            // Set the authorization token for the request
            _httpClient.SetToken(ApiAuthenticationScheme.Bearer, ResolveAccesToken(accessToken));

            // Construct the full URL with the base URL, version, and resource path
            var url = $"{_BaseUrl}v{(int)apiVersion}/{urlResourcePath}";

            // Append query parameters if any
            var uriBuilder = new UriBuilder(url)
            {
                Query = queryParams is not null ? 
                    ToolParameters.BuildQueryString(queryParams) :
                    string.Empty
            };

            // Log the request details for debugging
            _logger.LogDebug("URL: {@url}, Version: {@version}, Parameters: {@queryParams}",
                uriBuilder.Uri, apiVersion, queryParams);

            // Make the GET request
            var response = await _httpClient.GetAsync(uriBuilder.Uri).ConfigureAwait(false);

            // Handle response status codes and log errors as needed
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed with status code {@error}", response.StatusCode);

                return response.StatusCode switch
                {
                    HttpStatusCode.Forbidden => throw new ForbiddenException("Check permissions in your app or required scopes to do this action."),
                    HttpStatusCode.Unauthorized => throw new UnauthorizedAccessException("You are not authorized to access this resource."),
                    HttpStatusCode.InternalServerError => throw new InternalServerErrorException("An internal server error occurred. Please try again later."),
                    HttpStatusCode.NotFound => throw new NotFoundException("The requested resource was not found."),
                    _ => new TData(),// Creates an instance of T
                };
            }

            // Deserialize the response content into the expected data type
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedObj = JsonSerializer.Deserialize<WrapperResponse<TData>>(content);

            return deserializedObj?.Data; // Return the deserialized data
        }

        /// <summary>
        /// Sends a PATCH request to the API to update a resource.
        /// </summary>
        /// <typeparam name="TData">The type of data expected in the response.</typeparam>
        /// <param name="urlResourcePath">The relative URL path for the resource.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="input">The data to send in the request body.</param>
        /// <param name="accessToken">Optional access token for authorization.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        protected async Task<bool> PatchAsync<TData>(
            string urlResourcePath,
            ApiVersion apiVersion,
            TData input,
            string accessToken = null)
            where TData : class
        {
            ArgumentException.ThrowIfNullOrEmpty(urlResourcePath); // Ensure the URL resource path is provided

            // Set the authorization token for the request
            _httpClient.SetToken(ApiAuthenticationScheme.Bearer, ResolveAccesToken(accessToken));

            // Construct the full URL
            var url = $"{_BaseUrl}v{(int)apiVersion}/{urlResourcePath}";

            // Serialize the input data into JSON for the request body
            var json = JsonSerializer.Serialize(input);
            var payload = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            // Log the request details
            _logger.LogDebug("URL: {@url}, Version: {@version}, Parameters: {@queryParams}",
                url, apiVersion, payload);

            // Make the PATCH request
            var response = await _httpClient.PatchAsync(url, payload).ConfigureAwait(false);

            // Handle response status codes and log errors
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed with status code {@error}", response.StatusCode);

                return response.StatusCode switch
                {
                    HttpStatusCode.Forbidden => throw new ForbiddenException("Check permissions in your app or required scopes to do this action."),
                    HttpStatusCode.Unauthorized => throw new UnauthorizedAccessException("You are not authorized to access this resource."),
                    HttpStatusCode.InternalServerError => throw new InternalServerErrorException("An internal server error occurred. Please try again later."),
                    HttpStatusCode.NotFound => throw new NotFoundException("The requested resource was not found."),
                    _ => await Task.FromResult(false).ConfigureAwait(false),
                };
            }

            return await Task.FromResult(true).ConfigureAwait(false); // Return true if the request was successful
        }

        /// <summary>
        /// Sends a POST request to the API and returns the deserialized data.
        /// </summary>
        /// <typeparam name="TData">The type of data expected in the response.</typeparam>
        /// <param name="urlResourcePath">The relative URL path for the resource.</param>
        /// <param name="version">The API version to use.</param>
        /// <param name="accessToken">Optional access token for authorization.</param>
        /// <returns>Deserialized data from the response.</returns>
        protected Task<TData> PostAsync<TData>(
            string urlResourcePath,
            ApiVersion version,
            string accessToken = null)
            where TData : class, new()
        {
            return PostAsync<TData, object>(urlResourcePath, version, null, accessToken);
        }

        /// <summary>
        /// Sends a POST request to the API with input data and returns the deserialized data.
        /// </summary>
        /// <typeparam name="TData">The type of data expected in the response.</typeparam>
        /// <typeparam name="TInput">The type of data to send in the request body.</typeparam>
        /// <param name="urlResourcePath">The relative URL path for the resource.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="input">The data to send in the request body.</param>
        /// <param name="accessToken">Optional access token for authorization.</param>
        /// <returns>Deserialized data from the response.</returns>
        protected async Task<TData> PostAsync<TData, TInput>(
            string urlResourcePath,
            ApiVersion apiVersion,
            TInput input,
            string accessToken = null)
            where TData : class, new()
            where TInput : class
        {
            ArgumentException.ThrowIfNullOrEmpty(urlResourcePath); // Ensure the URL resource path is provided

            // Set the authorization token for the request
            _httpClient.SetToken(ApiAuthenticationScheme.Bearer, ResolveAccesToken(accessToken));

            // Construct the full URL
            var url = $"{_BaseUrl}v{(int)apiVersion}/{urlResourcePath}";

            // Serialize the input data into JSON if provided
            StringContent payload = null;
            if (input is not null)
            {
                var json = JsonSerializer.Serialize(input);
                payload = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            }

            // Log the request details
            _logger.LogDebug("URL: {@url}, Version: {@version}, Parameters: {@queryParams}",
                url, apiVersion, payload);

            // Make the POST request
            var response = await _httpClient.PostAsync(url, payload).ConfigureAwait(false);

            // Handle response status codes and log errors
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed with status code {@error}", response.StatusCode);

                return response.StatusCode switch
                {
                    HttpStatusCode.Forbidden => throw new ForbiddenException("Check permissions in your app or required scopes to do this action."),
                    HttpStatusCode.Unauthorized => throw new UnauthorizedAccessException("You are not authorized to access this resource."),
                    HttpStatusCode.InternalServerError => throw new InternalServerErrorException("An internal server error occurred. Please try again later."),
                    HttpStatusCode.NotFound => throw new NotFoundException("The requested resource was not found."),
                    _ => new TData(),// Creates an instance of T
                };
            }

            // Deserialize the response content into the expected data type
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var deserializedObj = JsonSerializer.Deserialize<WrapperResponse<TData>>(content);

            return deserializedObj?.Data; // Return the deserialized data
        }

        /// <summary>
        /// Sends a DELETE request to the API.
        /// </summary>
        /// <param name="urlResourcePath">The relative URL path for the resource.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="queryParams">Optional query parameters for the request.</param>
        /// <param name="accessToken">Optional access token for authorization.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        protected async Task<bool> DeleteAsync(
            string urlResourcePath,
            ApiVersion apiVersion,
            List<KeyValuePair<string, string>> queryParams = null,
            string accessToken = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(urlResourcePath); // Ensure the URL resource path is provided

            // Set the authorization token for the request
            _httpClient.SetToken(ApiAuthenticationScheme.Bearer, ResolveAccesToken(accessToken));

            // Construct the full URL
            var url = $"{_BaseUrl}v{(int)apiVersion}/{urlResourcePath}";

            // Append query parameters if any
            var uriBuilder = new UriBuilder(url)
            {
                Query = queryParams is not null ?
                    ToolParameters.BuildQueryString(queryParams) :
                    string.Empty
            };

            // Log the request details
            _logger.LogDebug("URL: {@url}, Version: {@version}, Parameters: {@queryParams}",
                url, apiVersion, queryParams);

            // Make the DELETE request
            var response = await _httpClient.DeleteAsync(uriBuilder.Uri).ConfigureAwait(false);

            // Handle response status codes and log errors
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed with status code {@error}", response.StatusCode);

                return response.StatusCode switch
                {
                    HttpStatusCode.Forbidden => throw new ForbiddenException("Check permissions in your app or required scopes to do this action."),
                    HttpStatusCode.Unauthorized => throw new UnauthorizedAccessException("You are not authorized to access this resource."),
                    HttpStatusCode.InternalServerError => throw new InternalServerErrorException("An internal server error occurred. Please try again later."),
                    HttpStatusCode.NotFound => throw new NotFoundException("The requested resource was not found."),
                    _ => false,
                };
            }

            return true; // Return true if the request was successful
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Retrieves the access token for the request.
        /// </summary>
        /// <param name="accessToken">The provided access token.</param>
        /// <returns>The access token to be used in the request.</returns>
        private string ResolveAccesToken(string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
                return accessToken;

            if (!string.IsNullOrWhiteSpace(_kickApiSettings.AccessToken))
                return _kickApiSettings.AccessToken;

            throw new ArgumentNullException(nameof(accessToken)); // Throw an exception if no token is provided
        }

        #endregion
    }
}
