using Microsoft.AspNetCore.Mvc;
using KickNetLib.Client;  // Importing the KickNetLib Client to interact with the Kick API
using KickNetLib.WebApi.Handlers;  // Importing the WebHookHandlerFactory to handle webhook events

namespace KickNetLib.WebApi.Controllers
{
    // The ApiController attribute marks this class as an API controller
    // This will automatically handle model binding and other API-related conventions
    [ApiController]

    // The Route attribute defines the base URL for the controller. This will respond to paths that start with "api/"
    [Route("api/")]
    public class WebHookController : ControllerBase
    {
        private readonly IKickClient _kickClient; // The Kick client for interacting with the Kick API
        private readonly ILogger<WebHookController> _logger; // Logger for logging information and errors

        // Injecting the WebHookHandlerFactory that will help create webhook event handlers
        private readonly WebHookHandlerFactory _webHookHandlerFactory;

        // Constructor to inject dependencies
        public WebHookController(
            IKickClient kickClient,  // The KickClient to manage webhook events
            ILogger<WebHookController> logger, // Logger to handle logs related to the controller
            WebHookHandlerFactory webHookHandlerFactory) // Factory to create the event handlers for webhooks
        {
            _kickClient = kickClient;  // Assign the injected KickClient to the class field
            _logger = logger;  // Assign the injected Logger to the class field
            _webHookHandlerFactory = webHookHandlerFactory;  // Assign the injected Factory to the class field

            // Create a set of webhook handlers via the factory
            var webHookHandlers = _webHookHandlerFactory.CreateHandlers();

            // Subscribe to the different webhook events to handle them when they occur
            _kickClient.WebHook.Events.OnChatMessageSent += webHookHandlers.ChatMessageSentHandler.Handle;  // Handle when a chat message is sent
            _kickClient.WebHook.Events.OnChannelFollowed += webHookHandlers.ChannelFollowedHandler.Handle;  // Handle when a channel is followed
            _kickClient.WebHook.Events.OnChannelGiftedSubscription += webHookHandlers.ChannelGiftedSubscriptionHandler.Handle;  // Handle when a gifted subscription is received
            _kickClient.WebHook.Events.OnChannelNewSubscription += webHookHandlers.ChannelNewSubscriptionHandler.Handle;  // Handle when a new channel subscription occurs
            _kickClient.WebHook.Events.OnChannelSubscriptionRenewal += webHookHandlers.ChannelSubscriptionRenewalHandler.Handle;  // Handle when a subscription is renewed
            _kickClient.WebHook.Events.OnLivestreamStatusUpdated += webHookHandlers.LivestreamStatusUpdatedHandler.Handle;  // Handle when the livestream status is updated
        }

        // This endpoint will handle incoming POST requests to the 'api/webhook' path
        // It will trigger events based on the incoming webhooks from Kick
        [HttpPost("webhook")]
        public async Task<IActionResult> ReceiveWebHook()
        {
            try
            {
                // Receive the webhook data from the HTTP context and process it with the Kick client
                await _kickClient.WebHook.ReciveWebHook(HttpContext);

                // Return an HTTP 200 OK response if the webhook is successfully processed
                return Ok();
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during webhook processing
                _logger.LogError(ex, "Error processing webhook.");

                // Return HTTP status 500 (Internal Server Error) if an exception is thrown during processing
                // Optionally, you can choose to return 200 OK to avoid automatic unsubscribe by error
                return StatusCode(500, "Internal server error");
                // To prevent automatic unsubscribe by error, you can return Ok() instead of StatusCode(500)
                // return Ok();
            }
        }
    }
}
