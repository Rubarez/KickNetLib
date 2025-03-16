using Microsoft.AspNetCore.Mvc;
using KickNetLib.Client.Models.Args;  // Importing the event argument models for the Kick API
using KickNetLib.Client;  // Importing the KickClient to interact with the Kick API

namespace KickNetLib.WebApi.Controllers
{
    // The ApiController attribute marks this class as an API controller
    // This enables automatic behavior like model binding, automatic HTTP 400 responses if model validation fails
    [ApiController]

    // The Route attribute defines the base URL for the controller. This will respond to paths that start with "api/"
    [Route("api/")]
    public class WebHookMinimalController : ControllerBase
    {
        private readonly IKickClient _kickClient;  // The KickClient to interact with the Kick API
        private readonly ILogger<WebHookMinimalController> _logger;  // Logger to log information and errors

        // Constructor to inject dependencies into the controller
        public WebHookMinimalController(
            IKickClient kickClient,  // Injecting the KickClient to interact with the Kick API
            ILogger<WebHookMinimalController> logger)  // Injecting the Logger to log events and errors
        {
            _kickClient = kickClient;  // Assigning the injected KickClient to the field
            _logger = logger;  // Assigning the injected Logger to the field

            // Subscribing to various webhook events when the controller is initialized
            _kickClient.WebHook.Events.OnChatMessageSent += Events_OnChatMessageSent;  // Event triggered when a chat message is sent
            _kickClient.WebHook.Events.OnChannelFollowed += Events_OnChannelFollowed;  // Event triggered when a channel is followed
            _kickClient.WebHook.Events.OnChannelGiftedSubscription += Events_OnChannelGiftedSubscription;  // Event triggered when a channel receives a gifted subscription
            _kickClient.WebHook.Events.OnChannelNewSubscription += Events_OnChannelNewSubscription;  // Event triggered when a channel gets a new subscription
            _kickClient.WebHook.Events.OnChannelSubscriptionRenewal += Events_OnChannelSubscriptionRenewal;  // Event triggered when a channel's subscription is renewed
            _kickClient.WebHook.Events.OnLivestreamStatusUpdated += Events_OnLivestreamStatusUpdated;  // Event triggered when a livestream's status is updated
        }

        // Event handler for the OnLivestreamStatusUpdated event
        void Events_OnLivestreamStatusUpdated(object sender, LivestreamStatusUpdatedEventArgs e)
        {
            _logger.LogInformation("OnLivestreamStatusUpdated: {@data}", e.Data);  // Log the event data
        }

        // Event handler for the OnChannelSubscriptionRenewal event
        void Events_OnChannelSubscriptionRenewal(object sender, ChannelSubscriptionRenewalEventArgs e)
        {
            _logger.LogInformation("OnChannelSubscriptionRenewal: {@data}", e.Data);  // Log the event data
        }

        // Event handler for the OnChannelNewSubscription event
        void Events_OnChannelNewSubscription(object sender, ChannelNewSubscriptionEventArgs e)
        {
            _logger.LogInformation("OnChannelNewSubscription: {@data}", e.Data);  // Log the event data
        }

        // Event handler for the OnChannelGiftedSubscription event
        void Events_OnChannelGiftedSubscription(object sender, ChannelGiftedSubscriptionEventArgs e)
        {
            _logger.LogInformation("OnChannelGiftedSubscription: {@data}", e.Data);  // Log the event data
        }

        // Event handler for the OnChannelFollowed event
        void Events_OnChannelFollowed(object sender, ChannelFollowedEventArgs e)
        {
            _logger.LogInformation("OnChannelFollowed: {@data}", e.Data);  // Log the event data
        }

        // Event handler for the OnChatMessageSent event
        void Events_OnChatMessageSent(object sender, ChatMessageSentEventArgs e)
        {
            _logger.LogInformation("OnChatMessageSent: {@data}", e.Data);  // Log the event data
        }

        // This method will handle incoming POST requests to the 'api/webhookminimal' endpoint
        [HttpPost("webhookminimal")]
        public async Task<IActionResult> ReceiveWebHook()
        {
            try
            {
                // Call the KickClient's method to process the incoming webhook using the current HTTP context
                await _kickClient.WebHook.ReciveWebHook(HttpContext);

                // If everything goes fine, return HTTP 200 OK
                return Ok();
            }
            catch (Exception ex)
            {
                // If an exception occurs while processing the webhook, log the error
                _logger.LogError(ex, "Error processing webhook.");

                // Return an HTTP 500 Internal Server Error response if an error occurs during webhook processing
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
