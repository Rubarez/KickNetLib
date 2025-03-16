
using System.Net;
using System.Text;

using KickNetLib.Client.Helpers;
using KickNetLib.Client.Models;

namespace KickNetLib.Client.Webhooks
{
    /// <summary>
    /// The WebHookListener class listens for incoming HTTP requests at a specified URL prefix
    /// and processes POST requests containing webhook events.
    /// This class is for only use in desktop apps and for test proupose. This class dont validate nothing
    /// </summary>
    public class WebHookListener
    {
        #region Members

        private readonly HttpListener _listener;
        private readonly WebHookEvent _events;
        private readonly WebHookEventManager _eventHandler;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WebHookListener"/> class.
        /// </summary>
        /// <param name="urlPrefix">The URL prefix that the listener should listen to (e.g., "http://localhost:8080/api/webhook/").</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="urlPrefix"/> is null or empty.</exception>
        public WebHookListener(string urlPrefix)
        {
            ArgumentException.ThrowIfNullOrEmpty(urlPrefix);

            _listener = new HttpListener();
            _listener.Prefixes.Add(urlPrefix);

            _events = new WebHookEvent();

            _eventHandler = new WebHookEventManager(_events);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Listens for incoming HTTP requests and processes them asynchronously.
        /// This method runs in a loop as long as the listener is active.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task ListenForRequests()
        {
            while (_listener.IsListening)
            {
                var context = await _listener.GetContextAsync();
                if (context.Request.HttpMethod == "POST")
                {
                    await HandlePostRequest(context);
                }
                context.Response.Close();
            }
        }

        /// <summary>
        /// Handles a POST request by reading the request body, checking headers, 
        /// processing the event, and sending an appropriate response.
        /// </summary>
        /// <param name="context">The HTTP listener context representing the incoming request.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task HandlePostRequest(HttpListenerContext context)
        {
            try
            {
                // Check if headers of kick are present
                if (!ToolHeader.CheckHeaders(context))
                    return;

                // Read the incoming request body (payload)
                using var reader = new StreamReader(context.Request.InputStream, Encoding.UTF8);
                string body = await reader.ReadToEndAsync();

                var kickEventType = context.Request.Headers[ToolHeader.HeaderKickEventType];

                _eventHandler.ManageEvent(kickEventType, body);

                // Send a success response back
                context.Response.StatusCode = 200;
                byte[] responseBytes = Encoding.UTF8.GetBytes("Request processed successfully.");
                await context.Response.OutputStream.WriteAsync(responseBytes);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                byte[] responseBytes = Encoding.UTF8.GetBytes($"Error: {ex.Message}");
                await context.Response.OutputStream.WriteAsync(responseBytes);
            }
        }

        #endregion

        #region Start/Stop Listener

        /// <summary>
        /// Starts the listener to begin receiving and processing HTTP requests.
        /// The listener runs in the background.
        /// </summary>
        public void StartListening()
        {
            if (_listener.IsListening) return;

            _listener.Start();
            
            Task.Run(() => ListenForRequests());
        }

        /// <summary>
        /// Stops the listener from receiving requests.
        /// </summary>
        public void StopListening()
        {
            if (_listener.IsListening)
                _listener.Stop();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="WebHookEvent"/> associated with this listener.
        /// </summary>
        public WebHookEvent Events => _events;

        #endregion
    }
}
