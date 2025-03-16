
using System.Diagnostics;
using System.Net;
using System.Text.Json;

using KickNetLib.DesktopFormsTool.Controls;
using KickNetLib.DesktopFormsTool.Models;
using KickNetLib.Api.Auth;
using KickNetLib.Client.Models.Args;
using KickNetLib.Client.Webhooks;
using KickNetLib.Api.Models.Settings;

namespace KickNetLib.DesktopFormsTool
{
    public partial class Main : Form
    {
        #region Members

        private const string BreakLines = "\r\n\r\n\r\n\r\n";

        private readonly KickOAuthSettings _kickOAuthSettings;
        private readonly KickApiSettings _kickApiSettings;
        private readonly KickOAuthClient _kickOAuthClient;

        private TokenInfo _tokenInfo = new();

        private HttpListener _httpListener;

        private KickOAuthTokenResponse _kickOAuthTokenResponse;

        // Event to notify about the variable change
        private event Action _globalVariableChanged;

        // Only for test prouposes
        private WebHookListener _webHookListener = new WebHookListener("http://localhost:7121/api/webhook/");

        private int _eventCounter = 0; // Event counter

        #endregion

        #region Constructor

        public Main()
        {
            _kickOAuthSettings = new KickOAuthSettings()
            {
                BaseUrl = "https://id.kick.com/",
                AuthorizationEndpointPath = "oauth/authorize",
                TokenEndpointPath = "oauth/token",
                RevokeEndpointTokenPath = "oauth/revoke",
                RedirectUri = "http://localhost:7121/api/authcallback",
                ClientID = "YOUR_CLIENT_ID",
                ClientSecret = "YOUR_CLIENT_SECRET",
                Scopes = KickScope.AllScopes
            };

            _kickApiSettings = new KickApiSettings()
            {
                BaseUrl = "https://api.kick.com/public/",
                AccessToken = "" // If you have an access token, you can provide it here. But be careful with the expiration
            };

            _kickOAuthClient = new(_kickOAuthSettings);

            InitializeComponent();

            bsTokenInfo.DataSource = _tokenInfo;

            btnRefreshToken.Enabled = false;
            btnRevokeToken.Enabled = false;

            if (!string.IsNullOrEmpty(KickApiSettings.AccessToken))
                _tokenInfo.AccessToken = KickApiSettings.AccessToken;
        }

        #endregion

        #region HTTP Listener

        private void StartHttpListener()
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(_kickOAuthSettings.RedirectUri + "/");
            _httpListener.Start();

            // Listen for incoming requests
            Console.WriteLine("Listening for OAuth2 callback...");

            // Get the request
            HttpListenerContext context = _httpListener.GetContext();
            string code = context.Request.QueryString["code"];  // Extract the 'code' query parameter from the URL
            string codeVerifier = context.Request.QueryString["state"];

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(codeVerifier))
            {
                Console.WriteLine("Authorization code received: " + code);
                SendResponse(context.Response);

                _kickOAuthTokenResponse = _kickOAuthClient.ExchangeAuthCodeForAccessToken(code, codeVerifier);  // Now exchange the code for an access token

                AsignInfoToken(_kickOAuthTokenResponse);

                _globalVariableChanged?.Invoke();

                Invoke(new Action(() =>
                {
                    btnRefreshToken.Enabled = true;
                    btnRevokeToken.Enabled = true;
                }));
            }
            else
            {
                Console.WriteLine("No authorization code received.");
                SendErrorResponse(context.Response);
            }
        }

        private void SendResponse(HttpListenerResponse response)
        {
            string responseString = "<html><body>OAuth2 Authorization Complete! You can close this window.</body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
            _httpListener.Stop();
        }

        private void SendErrorResponse(HttpListenerResponse response)
        {
            string errorResponse = "<html><body>Error: No authorization code received. You can close this window.</body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(errorResponse);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
            _httpListener.Stop();
        }

        #endregion

        #region Button Events Auth

        private void BtnStartAuth_Click(object sender, EventArgs e)
        {
            try
            {
                // Start the listener in a background thread
                Thread listenerThread = new Thread(new ThreadStart(StartHttpListener));
                listenerThread.Start();

                _kickOAuthClient.ProcessAuthorization();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefreshTokenAuth_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_tokenInfo.RefreshToken))
                {
                    MessageBox.Show("The refresh token is missing.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                _kickOAuthTokenResponse = _kickOAuthClient.ExchangeTokenFromRefreshToken(_tokenInfo.RefreshToken);

                AsignInfoToken(_kickOAuthTokenResponse);

                _globalVariableChanged?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRevokeToken_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_tokenInfo.AccessToken))
                {
                    MessageBox.Show("The access token is missing.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                bool isRevoked = _kickOAuthClient.RevokeToken(_tokenInfo.AccessToken, TokenType.AccessToken);

                if (!isRevoked)
                {
                    MessageBox.Show("The token was not revoked.", "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                // Reset Buttons
                btnRefreshToken.Enabled = false;
                btnRevokeToken.Enabled = false;

                // Reset data
                _tokenInfo = new TokenInfo();
                bsTokenInfo.DataSource = _tokenInfo;

                _kickApiSettings.AccessToken = "";

                RefreshBidings();

                _globalVariableChanged?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helpers

        private void ChangeNumberEvent()
        {
            _eventCounter++;
            Invoke(new Action(() =>
            {
                tpEvents.Text = $"Events ({_eventCounter})";
            }));
        }

        private void AsignInfoToken(KickOAuthTokenResponse kickOAuthTokenResponse)
        {
            if (kickOAuthTokenResponse is null)
            {
                return;
            }

            _tokenInfo.AccessToken = kickOAuthTokenResponse.AccessToken;
            _tokenInfo.RefreshToken = kickOAuthTokenResponse.RefreshToken;

            _tokenInfo.TokenExpireAt = DateTime.Now.AddSeconds(kickOAuthTokenResponse.ExpiresIn);

            _kickApiSettings.AccessToken = kickOAuthTokenResponse.AccessToken;

            RefreshBidings();
        }

        private void RefreshBidings()
        {
            Invoke(new Action(() =>
            {
                bsTokenInfo.ResetBindings(false);
            }));
        }


        #endregion

        #region Events Tabs

        private void tbAPIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbAPIS.SelectedTab is null)
                    return;

                TabPage tp = null;
                BaseAPIControl aPIControl = null;

                switch (tbAPIS.SelectedTab.Name)
                {
                    case "tpCategories":
                        aPIControl = new CategoryAPIControl(this);
                        tp = tpCategories;
                        break;

                    case "tpUsers":
                        aPIControl = new UserAPIControl(this);
                        tp = tpUsers;
                        break;

                    case "tpChannels":
                        aPIControl = new ChannelAPIControl(this);
                        tp = tpChannels;
                        break;

                    case "tpPublicKey":
                        aPIControl = new PublicKeyAPIControl(this);
                        tp = tpPublicKey;
                        break;

                    case "tpEventsSuscriptions":
                        aPIControl = new EventSuscriptionAPIControl(this);
                        tp = tpEventsSuscriptions;
                        break;

                    case "tpChat":
                        aPIControl = new ChatAPIControl(this);
                        tp = tpChat;
                        break;

                    case "tpToken":
                        aPIControl = new TokenAPIControl(this);
                        tp = tpToken;
                        break;

                    default:
                        throw new ArgumentException($"Tab {tbAPIS.SelectedTab.Name} not has a handler");
                }

                _globalVariableChanged += aPIControl.OnGlobalVariableChanged;
                aPIControl.Dock = DockStyle.Fill;
                tp.Controls.Add(aPIControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Event Listener

        void Events_OnLivestreamStatusUpdated(object sender, LivestreamStatusUpdatedEventArgs e)
        {
            Debug.WriteLine(e.Data);
            Invoke(new Action(() =>
            {
                txtEvents.AppendText(JsonSerializer.Serialize(e.Data, new JsonSerializerOptions { WriteIndented = true }) + BreakLines);
                txtEvents.ScrollToCaret();
            }));
            ChangeNumberEvent();
        }

        void Events_OnChannelSubscriptionRenewal(object sender, ChannelSubscriptionRenewalEventArgs e)
        {
            Debug.WriteLine(e.Data);
            Invoke(new Action(() =>
            {
                txtEvents.AppendText(JsonSerializer.Serialize(e.Data, new JsonSerializerOptions { WriteIndented = true }) + BreakLines);
                txtEvents.ScrollToCaret();
            }));
            ChangeNumberEvent();
        }

        void Events_OnChannelNewSubscription(object sender, ChannelNewSubscriptionEventArgs e)
        {
            Debug.WriteLine(e.Data);
            Invoke(new Action(() =>
            {
                txtEvents.AppendText(JsonSerializer.Serialize(e.Data, new JsonSerializerOptions { WriteIndented = true }) + BreakLines);
                txtEvents.ScrollToCaret();
            }));
            ChangeNumberEvent();
        }

        void Events_OnChannelGiftedSubscription(object sender, ChannelGiftedSubscriptionEventArgs e)
        {
            Debug.WriteLine(e.Data);
            Invoke(new Action(() =>
            {
                txtEvents.AppendText(JsonSerializer.Serialize(e.Data, new JsonSerializerOptions { WriteIndented = true }) + BreakLines);
                txtEvents.ScrollToCaret();
            }));
            ChangeNumberEvent();
        }

        void Events_OnChannelFollowed(object sender, ChannelFollowedEventArgs e)
        {
            Debug.WriteLine(e.Data);
            Invoke(new Action(() =>
            {
                txtEvents.AppendText(JsonSerializer.Serialize(e.Data, new JsonSerializerOptions { WriteIndented = true }) + BreakLines);
                txtEvents.ScrollToCaret();
            }));
            ChangeNumberEvent();
        }

        void Events_OnChatMessageSent(object sender, ChatMessageSentEventArgs e)
        {Debug.WriteLine(e.Data);
            Invoke(new Action(() =>
            {
                txtEvents.AppendText(JsonSerializer.Serialize(e.Data, new JsonSerializerOptions { WriteIndented = true }) + BreakLines);
                txtEvents.ScrollToCaret();
            }));
            ChangeNumberEvent();
        }

        #endregion

        #region Event Load

        private void Main_Load(object sender, EventArgs e)
        {
            _webHookListener.StartListening();

            _webHookListener.Events.OnChatMessageSent += Events_OnChatMessageSent;
            _webHookListener.Events.OnChannelFollowed += Events_OnChannelFollowed;
            _webHookListener.Events.OnChannelGiftedSubscription += Events_OnChannelGiftedSubscription;
            _webHookListener.Events.OnChannelNewSubscription += Events_OnChannelNewSubscription;
            _webHookListener.Events.OnChannelSubscriptionRenewal += Events_OnChannelSubscriptionRenewal;
            _webHookListener.Events.OnLivestreamStatusUpdated += Events_OnLivestreamStatusUpdated;

            tbAPIS.SelectedTab = null;
            tbAPIS.SelectedTab = tpCategories;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _webHookListener.StopListening();
        }

        #endregion

        #region Properties

        public KickApiSettings KickApiSettings { get { return _kickApiSettings; } }

        #endregion
    }
}
