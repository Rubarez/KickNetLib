
using Microsoft.Extensions.Logging;

using KickNetLib.Api.Models.Core;
using KickNetLib.Api.ApiClients.V1.EventSuscriptions.Models;
using KickNetLib.Api.Models.Settings;

namespace KickNetLib.Api.ApiClients
{
    /// <summary>
    /// Client for interacting with event subscription-related API endpoints in the Kick API.
    /// Inherits from BaseApiClient to provide common HTTP request functionality.
    /// </summary>
    public class EventSuscriptionApiClient : BaseApiClient
    {
        #region Members

        /// <summary>
        /// The resource path for event subscriptions.
        /// </summary>
        private const string UrlResourcePath = "events/subscriptions";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the EventSuscriptionApiClient class.
        /// </summary>
        /// <param name="logger">Logger for logging requests and responses.</param>
        /// <param name="kickSettings">Settings for Kick API configuration, such as access token and base URL.</param>
        public EventSuscriptionApiClient(ILogger logger, KickApiSettings kickSettings) : base(logger, kickSettings) { }

        #endregion

        #region HTTP Methods

        /// <summary>
        /// Retrieves a list of event subscriptions for the authenticated user.
        /// </summary>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A list of event subscriptions.</returns>
        public async Task<List<EventSuscription>> GetEventsSuscriptionsAsync(string accessToken = null)
        {
            var url = $"{UrlResourcePath}";

            return await GetAsync<List<EventSuscription>>(url, ApiVersion.V1, null, accessToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Subscribes to a list of event types.
        /// </summary>
        /// <param name="eventTypes">A collection of event types to subscribe to.</param>
        /// <param name="version">The version of the event subscription request.</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A list of responses for each event subscription request.</returns>
        /// <exception cref="ArgumentException">Thrown if the eventTypes collection is empty or version is less than 1.</exception>
        public async Task<List<AddEnventSuscriptionResponse>> SubscribeToEventsAsync(
            ICollection<EventType> eventTypes,
            int version,
            string accessToken = null)
        {
            if (eventTypes.Count == 0)
            {
                throw new ArgumentException("At least one event type must be provided!");
            }

            if (version < 1)
            {
                throw new ArgumentException("Version must be at least 1!");
            }

            AddEventSuscription addEventSuscription = new();

            foreach (EventType eventType in eventTypes)
            {
                addEventSuscription.AddEvent(eventType, version);
            }

            return await PostAsync<List<AddEnventSuscriptionResponse>, AddEventSuscription>(
                    UrlResourcePath,
                    ApiVersion.V1,
                    addEventSuscription,
                    accessToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Unsubscribes from a list of event subscriptions by their IDs.
        /// </summary>
        /// <param name="subscriptionIds">A collection of subscription IDs to unsubscribe from.</param>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A boolean indicating whether the unsubscribe request was successful.</returns>
        /// <exception cref="ArgumentException">Thrown if the subscriptionIds collection is empty.</exception>
        public async Task<bool> UnsubscribeEventsAsync(ICollection<string> subscriptionIds, string accessToken = null)
        {
            if (subscriptionIds.Count == 0)
            {
                throw new ArgumentException("At least one event type must be provided!");
            }

            var query = subscriptionIds
            .Distinct()
            .Select(id => new KeyValuePair<string, string>("id", id))
            .ToList();

            return await DeleteAsync(
                UrlResourcePath,
                ApiVersion.V1,
                query,
                accessToken);
        }

        /// <summary>
        /// Unsubscribes from all active event subscriptions for the authenticated user.
        /// </summary>
        /// <param name="accessToken">The access token for authorization. Uses the configured token if null.</param>
        /// <returns>A boolean indicating whether the unsubscribe request was successful.</returns>
        public async Task<bool> UnsubscribeAllEventsAsync(string accessToken = null)
        {
            var activeSubscriptions = await GetAsync<List<EventSuscription>>(UrlResourcePath, ApiVersion.V1, null, accessToken);

            List<string> subscriptionIds = activeSubscriptions.Select(x => x.Id).ToList();

            return await UnsubscribeEventsAsync(subscriptionIds, accessToken);
        }

        #endregion
    }
}
