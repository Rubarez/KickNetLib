using Microsoft.AspNetCore.Mvc;
using KickNetLib.Api;
using KickNetLib.Api.Auth;

namespace KickNetLib.WebApi.Controllers
{
    // The ApiController attribute indicates that this class is an API controller
    [ApiController]
    // The Route attribute defines the base URL path for the controller's actions
    [Route("api/")]
    public class ApiAuthController : ControllerBase
    {
        private readonly IKickApi _kickApi; // IKickApi instance for making API calls
        private readonly ILogger<ApiAuthController> _logger; // Logger for logging exceptions and important information

        // Constructor to inject dependencies: IKickApi and ILogger
        public ApiAuthController(
            IKickApi kickApi, // Dependency Injection of the Kick API service
            ILogger<ApiAuthController> logger) // Dependency Injection of the logger service
        {
            _kickApi = kickApi; // Assigning the injected service to the class's private field
            _logger = logger; // Assigning the injected logger to the class's private field
        }

        // API endpoint to initiate the authentication process (POST)
        [HttpPost("authkick")]
        public IActionResult ApiAuthKick()
        {
            try
            {
                // Call the authentication process of the Kick API
                _kickApi.Authentication.ProcessAuthorization(["user:read", "channel:read"]);

                // Return HTTP status 200 (OK) if the process succeeds
                return Ok();
            }
            catch (Exception ex)
            {
                // Log any exception that occurs during the authentication process
                _logger.LogError(ex, "Error processing apikick.");
                // Return HTTP status 500 (Internal Server Error) if an exception is thrown
                return StatusCode(500, "Internal server error");
            }
        }

        // API endpoint for handling the callback after authentication (GET)
        [HttpGet("authcallback")]
        public IActionResult ApiAuthKickCallback()
        {
            try
            {
                // Extract 'code' and 'state' query parameters from the URL
                string code = HttpContext.Request.Query["code"];
                string codeVerifier = HttpContext.Request.Query["state"];

                // Check if both the 'code' and 'state' are present
                if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(codeVerifier))
                {
                    // Log the received authorization code for debugging
                    _logger.LogDebug("Authorization code received: " + code);

                    // Exchange the authorization code for an access token
                    var tokenResponse = _kickApi.Authentication.ExchangeAuthCodeForAccessToken(code, codeVerifier);

                    // Log that we received an authorization code
                    _logger.LogDebug("Authorization code received and exchanged for access token.");
                    return Ok(tokenResponse); // Return the access token response
                }
                else
                {
                    // If 'code' or 'state' is missing, log the error and return a bad request response
                    _logger.LogError("No authorization code received.");
                    return BadRequest(); // HTTP 400 for bad request
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the callback process
                _logger.LogError(ex, "Error processing authcallback.");
                // Return HTTP status 500 (Internal Server Error) if an exception is thrown
                return StatusCode(500, "Internal server error");
            }
        }

        // API endpoint for refreshing an authentication token (POST)
        [HttpPost("authkickrefresh")]
        public IActionResult ApiAuthKickRefresh([FromForm] string refreshToken)
        {
            try
            {
                // Exchange the refresh token for a new access token
                var tokenResponse = _kickApi.Authentication.ExchangeTokenFromRefreshToken(refreshToken);

                // Return the new token in the response
                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                // Log any exception that occurs during token refresh
                _logger.LogError(ex, "Error processing authkickrefresh.");
                // Return HTTP status 500 (Internal Server Error) if an exception is thrown
                return StatusCode(500, "Internal server error");
            }
        }

        // API endpoint for revoking an authentication token (POST)
        [HttpPost("authkickrevoke")]
        public IActionResult ApiAuthKickRevoke([FromForm] string acesstoken)
        {
            try
            {
                // Revoke the provided token using the Kick API
                var resultRevoke = _kickApi.Authentication.RevokeToken(acesstoken, TokenType.AccessToken);

                // Return the result of the revoke action (e.g., success or failure)
                return Ok(resultRevoke);
            }
            catch (Exception ex)
            {
                // Log any exception that occurs during token revocation
                _logger.LogError(ex, "Error processing authkickrevoke.");
                // Return HTTP status 500 (Internal Server Error) if an exception is thrown
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
