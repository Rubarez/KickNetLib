using Microsoft.AspNetCore.Mvc;
using KickNetLib.Api;

namespace KickNetLib.WebApi.Controllers
{
    // The ApiController attribute marks this class as an API controller, which simplifies model binding, 
    // and enables automatic HTTP 400 responses if model validation fails
    [ApiController]

    // The Route attribute defines the base route for the controller. The controller will respond to paths starting with "api/"
    [Route("api/")]
    public class ApiController : ControllerBase
    {
        private readonly IKickApi _kickApi; // The Kick API service that provides various API methods
        private readonly ILogger<ApiController> _logger; // Logger for logging events and errors

        // Constructor for dependency injection of the IKickApi and ILogger
        public ApiController(
            IKickApi kickApi, // The Kick API service is injected to handle API calls
            ILogger<ApiController> logger) // Logger service is injected to log errors and information
        {
            _kickApi = kickApi; // Assign the injected Kick API service to a class field
            _logger = logger; // Assign the injected logger to a class field
        }

        // This method handles incoming POST requests to the 'api/apikick' endpoint
        // It is designed to trigger events based on incoming webhooks or actions
        [HttpPost("apikick")]
        public async Task<IActionResult> ApiKick()
        {
            try
            {
                // If the access token is available in the configuration file (e.g., config.json), we can call the API.
                // Here, the 'GetCategoryByIdAsync' method fetches the category with ID 1 (with no explicit access token)
                var categories1 = await _kickApi.Categories.GetCategoryByIdAsync(1);

                // If the access token is stored elsewhere (e.g., in Redis, session, or other storage),
                // it can be passed explicitly as an argument to the 'GetCategoryByIdAsync' method.
                var categories2 = await _kickApi.Categories.GetCategoryByIdAsync(1, "MY_ACCESS_TOKEN");

                // Return the result (categories1) as a successful HTTP response
                return Ok(categories1);
            }
            catch (Exception ex)
            {
                // If any exception occurs during the API call, log the error
                _logger.LogError(ex, "Error processing apikick.");

                // Return a 500 (Internal Server Error) response along with a generic error message
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
