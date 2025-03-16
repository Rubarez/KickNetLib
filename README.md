<p align="center"> 
<img src="https://github.com/Rubarez/KickNetLib/blob/master/res/KickNetLibLogo.png" style="max-height: 250px !important;">
</p>

<p align="center">
<a href="https://www.microsoft.com/net"><img src="https://img.shields.io/badge/-.NET%208.0-blueviolet" style="max-height: 300px;"></a>
<a href="https://www.microsoft.com/net"><img src="https://img.shields.io/badge/-.NET%209.0-blueviolet" style="max-height: 300px;"></a>
<img src="https://img.shields.io/badge/Platform-.NET-lightgrey.svg" style="max-height: 300px;">
<a href="https://github.com/Rubarez/KickNetLib/blob/master/LICENSE"><img src="https://img.shields.io/badge/License-MIT-yellow.svg" style="max-height: 300px;"></a>
<a href="https://www.nuget.org/packages/KickNetLib"><img src="https://img.shields.io/nuget/dt/KickNetLib?label=NuGet&color=orange" style="max-height: 300px;"></a>
</p>

<p align="center">
  <a href='https://ko-fi.com/rubarez' target='_blank'>
  <img height='30' style='border:0;height:38px;' src='https://storage.ko-fi.com/cdn/kofi6.png?v=6' border='0' alt='Buy Me a Coffee at ko-fi.com' />
</a>


# About <i>KickNetLib</i> :information_source:

KickNetLib is a library in **C#** for use into **.NET 8 and .NET 9**. The library interacts with the **official API and the Webhooks of Kick**. (https://kick.com).

### KickNetLib Features :top:

#### [Client (Webhooks)]

* **Read and validate incoming webhooks**
  * Enable/Disable signature validation
* **Reading Channel events**
  * New follower (channel.followed)
  * New renewal subscription (channel.subscription.renewal)
  * New gift subscriptions (channel.subscription.gifts)
  * New subscriptor (channel.subscription.new)
* **Reading Chat events**
  * ChatMessageSent (chat.message.sent)
* **Reading Live stream events**
  * Live stream status updated to ON (livestream.status.updated)
  * Live stream status updated to OF (livestream.status.updated)
  
  
#### [API]

* **Authentication Flow**
  * Authorization Endpoint *(/oauth/authorize)*
  * Token Endpoint *(/oauth/token)*
  * Refresh Token Endpoint *(/oauth/token)*
  * Revoke Token Endpoint *(/oauth/revoke)*
* **Categories**
  * Get channels by name *(GET /categories?q=)*
  * Get category by category_id *(GET /categories/:category_id)*
* **Channels**
  * Get Channels filter by Broadcaster User IDs *(GET /channels?broadcaster_user_id=)*
  * Update the title and category of the channel *(PATCH /channels)*
* **Chat**
  * Send a message to the chat as BOT and USER *(POST /chat)*
* **Public key**
  * Get the public key for verify signatures *(GET /public-key)*
* **Users**
  * Get information about token passed *(POST /token/introspect)*
  * Get users filter by User IDs *(GET /users?id=)*


## Projects :file_folder:

The repo has a 6 projects:

- [KickNetDesktopForms](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/kickNetDesktopForms)

	- It is a tool-app developed in windows forms. Is used to facilitate testing and perform operations quickly.
	- It Is only for develop or test prouposes.

- [KickNetLib.Api](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/KickNetLib.Api)

	- It is the project that interacts with the Kick API.

- [KickNetLib.Client](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/KickNetLib.Client)

	- It is the project that interacts with the Kick Webhooks.

- [KickNetLib.Shared](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/KickNetLib.Shared)

	- The project provides shared resources for the API and Webhooks.
	
- [KickNetLib](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/KickNetLib)

	- Is the project Meta-Package for nuget.

- [KickNetLib.Tests](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/KickNetLib.Tests)

	- It is the project for tests. TODO.

- [KickNetLib.WebApi](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/KickNetLib.WebApi)

	- Is the project skeleton with all you need to start build your app.

## Before starting :triangular_ruler:

First, you need to create a new app on Kick: https://kick.com/settings/developer

Follow the instructions of the docs: https://docs.kick.com/getting-started/kick-apps-setup


## How to use :memo:


## Installing :fast_forward:

KickNetLib is available on NuGet. To install all packages, you can run the following commands:

```
PM> Install-Package KickNetLib
```
Or from the .NET CLI as:
```
dotnet add package KickNetLib
```

## Using KickNetLib

**The simple way:** :pill:

You can follow the structure of the skeleton web API. [KickNetLib.WebApi](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/KickNetLib.WebApi)

**In the other way** :bomb:

You’ll find all the information below.

### [Webhooks]

### With Dependency Injection :syringe:

#### - Configuration :wrench:

First, you need to provide a configuration for WebHooks in the **appsettings.json** like this:

```json
"KickWebHookSettings": {
  "ValidateSender": true,
  "PublicKeyPem": "-----BEGIN PUBLIC KEY-----\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq/+l1WnlRrGSolDMA+A8\n6rAhMbQGmQ2SapVcGM3zq8ANXjnhDWocMqfWcTd95btDydITa10kDvHzw9WQOqp2\nMZI7ZyrfzJuz5nhTPCiJwTwnEtWft7nV14BYRDHvlfqPUaZ+1KR4OCaO/wWIk/rQ\nL/TjY0M70gse8rlBkbo2a8rKhu69RQTRsoaf4DVhDPEeSeI5jVrRDGAMGL3cGuyY\n6CLKGdjVEM78g3JfYOvDU/RvfqD7L89TZ3iN94jrmWdGz34JNlEI5hqK8dd7C5EF\nBEbZ5jgB8s8ReQV8H+MkuffjdAj3ajDDX3DOJMIut1lBrUVD1AaSrGCKHooWoL2e\ntwIDAQAB\n-----END PUBLIC KEY-----"
}
```

##### Basic

| Field         | Description                                                                                     | Type  | Default Value |
|---------------|-------------------------------------------------------------------------------------------------|-------|---------------|
| ValidateSender| Enable or disable if the system must verify kick is the sender.                                 | Bool  | true          |
| PublicKeyPem  | Provide a Public Key Pem for checking the message sign.                                         | String| (No default provided) |


#### - Usage

You can easily add KickNetLib.Client via extension method `.AddKickLibClient(builder.Configuration);`, that will register all related services with Scoped lifetime.

Now, you can use `KickClient` with the `IKickClient` interface in your controller like this:

```csharp
public class MyController : ControllerBase
{
	private readonly IKickClient _kickClient;
	
	public MyController(IKickClient kickClient) {
		_kickClient = kickClient;
	}
	
	private async Task Method() {
		await _kickClient.WebHook.ReciveWebHook(HttpContext);
	}
}
```


### Without Dependency Injection :page_facing_up:

First you need provide a configuration creating a object **kickClient**, and then you can use it.

```csharp
string PublicKeyPem = @"-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq/+l1WnlRrGSolDMA+A8
6rAhMbQGmQ2SapVcGM3zq8ANXjnhDWocMqfWcTd95btDydITa10kDvHzw9WQOqp2
MZI7ZyrfzJuz5nhTPCiJwTwnEtWft7nV14BYRDHvlfqPUaZ+1KR4OCaO/wWIk/rQ
L/TjY0M70gse8rlBkbo2a8rKhu69RQTRsoaf4DVhDPEeSeI5jVrRDGAMGL3cGuyY
6CLKGdjVEM78g3JfYOvDU/RvfqD7L89TZ3iN94jrmWdGz34JNlEI5hqK8dd7C5EF
BEbZ5jgB8s8ReQV8H+MkuffjdAj3ajDDX3DOJMIut1lBrUVD1AaSrGCKHooWoL2e
twIDAQAB
-----END PUBLIC KEY-----"; 

IKickClient kickClient = new KickClient(validateSender: true, PublicKeyPem: PublicKeyPem);

private async Task Method() {
	await _kickClient.WebHook.ReciveWebHook(httpContext);
}
```

### [API]

### With Dependency Injection :syringe:

#### - Configuration :wrench:

First you need provide a configuration for Api in the **appsettings.json** like this:

```json
"KickApiSettings": {
"BaseUrl": "https://api.kick.com/public/",
"AccessToken": "",
"KickOAuthSettings": {
	"BaseUrl": "https://id.kick.com/",
	"AuthorizationEndpointPath": "oauth/authorize",
	"TokenEndpointPath": "oauth/token",
	"RevokeEndpointTokenPath": "oauth/revoke",
	"RedirectUri": "YOUR_REDIRECT_URL",
	"ClientID": "YOUR_CLIENT_ID",
	"ClientSecret": "YOUR_CLIENT_SECRET",
	"Scopes": [ "user:read", "channel:read", "channel:write", "chat:write", "streamkey:read", "events:subscribe" ]
	}
}
```

##### Basic

| Field       | Description                                                                      | Type   | Default Value                  |
|-------------|----------------------------------------------------------------------------------|--------|--------------------------------|
| BaseUrl     | The url base of kick API.                                                        | String | https://api.kick.com/public/   |
| AccessToken | If you have an access token with more persistence like normal, you can put here. | String | (No default provided)          |

##### Auth

| Field                     | Description                                                                                                  | Type               | Default Value                                                                                                             |
|---------------------------|--------------------------------------------------------------------------------------------------------------|--------------------|---------------------------------------------------------------------------------------------------------------------------|
| BaseUrl                   | The url base of kick API auth.                                                                               | String             | https://id.kick.com/                                                                                                      |
| AuthorizationEndpointPath | The path action of authorization endpoint.                                                                   | String             | oauth/authorize                                                                                                           |
| TokenEndpointPath         | The path action of authorization for exchange a token.                                                       | String             | oauth/token                                                                                                               |
| RevokeEndpointTokenPath   | The path action to revoke a token.                                                                           | String             | oauth/token                                                                                                               |
| RedirectUri               | The URI to redirect users to after authorization. You need to configure the same value in your app kick.     | String             | http://localhost:7121/api/authcallback                                                                                    |
| ClientID                  | Your app kick client ID. You can get it in https://kick.com/settings/developer.                              | String             | (No default provided)                                                                                                     |
| ClientSecret              | Your app kick client secret. You can get it in https://kick.com/settings/developer.                          | String             | (No default provided)                                                                                                     |
| Scopes                    | These scopes are for apps using OAuth 2.1 authorization code grants for authorization. You need get Permissions configured in app Kick                      | Array of String    | [ "user:read", "channel:read", "channel:write", "chat:write", "streamkey:read", "events:subscribe" ]                      |


#### - Usage

You can easily add KickNetLib.Api via extension method `.AddKickLibApi(builder.Configuration);`, that will register all related services with Scoped lifetime.

Now you can use `KickApi` with the interface `IKickApi` in your controller like this:

```csharp
public class MyController : ControllerBase
{
	private readonly IKickApi _kickApi;
	
	public MyController(IKickApi kickAp) {
		_kickApi = kickApi;
	}
	
	private async Task Method() {
		// Get Category by Id
		await _kickApi.Categories.GetCategoryByIdAsync(1);
		
		// Get users by Ids
		await _kickApi.Users.GetUserByIdsAsync(["1"]);
	}
}
```


### + Without Dependency Injection :page_facing_up:

First you need provide a configuration creating a object **kickApi**, and then you can use it.

```csharp
public class Main
{
	private _kickOAuthSettings = new KickOAuthSettings()
	{
		BaseUrl = "https://id.kick.com/",
		AuthorizationEndpointPath = "oauth/authorize",
		TokenEndpointPath = "oauth/token",
		RevokeEndpointTokenPath = "oauth/revoke",
		RedirectUri = "YOUR_REDIRECT_URL",
		ClientID = "YOUR_CLIENT_ID",
		ClientSecret = "YOUR_CLIENT_SECRET",
		Scopes = KickScope.AllScopes
	};

	private _kickApiSettings = new KickApiSettings()
	{
		BaseUrl = "https://api.kick.com/public/",
		AccessToken = ""
	};
	
	private async Task Method() {
		// You must have a AccessToken to use kickApi
		// For generate it, follow the manual
		KickApi kickApi = new KickApi(_kickApiSettings);
		
		// Get Category by Id
		await _kickApi.Categories.GetCategoryByIdAsync(1);
		
		// Get users by Ids
		await _kickApi.Users.GetUserByIdsAsync(["1"]);
	}
}
```

## Examples :arrow_lower_right:
 
 
### Authentication flow


#### Call ProcessAuthorization

This method open a browser with a kick security page https://id.kick.com/oauth/authorize to confirm permissions.

```csharp
// Call the authentication process of the Kick API. 
// The scopes are defined in the appsettings.json file
_kickApi.Authentication.ProcessAuthorization();
```

If you want override the scopes to send as you want

```csharp
// Call the authentication process of the Kick API
// With your custom scopes user:read and channel:read
 _kickApi.Authentication.ProcessAuthorization(["user:read", "channel:read"]);
```

#### Callback

You need to implement a callback to manage info recived from kick.
This info will be use to exchange for an access token.

```csharp
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
```

#### Refresh Token

```csharp
// Exchange the refresh token for a new access token
var tokenResponse = _kickApi.Authentication.ExchangeTokenFromRefreshToken("YOUR_REFRESH_TOKEN");
```

#### Revoke Token

```csharp
// Revoke the provided token using the Kick API
// You can use your access token or refresh token
var resultRevoke = _kickApi.Authentication.RevokeToken("YOUR_TOKEN", TokenType.AccessToken);
```

### API

_kickApi object has a diffrent properties to manage the apis. Like: Categories, Authentication, Chat, Channels, etc.

```csharp
// If the access token is available in the configuration file (e.g., config.json), we can call the API.
// Note: Token expire is short. Be carefull with this.
// Here, the 'GetCategoryByIdAsync' method fetches the category with ID 1 (with no explicit access token)
var category = await _kickApi.Categories.GetCategoryByIdAsync(1);
```

OR

```csharp
// If the access token is stored elsewhere (e.g., in Redis, session, or other storage),
// it can be passed explicitly as an argument to the 'GetCategoryByIdAsync' method.
var category = await _kickApi.Categories.GetCategoryByIdAsync(1, "MY_ACCESS_TOKEN");
```

### WebHooks

In the configuration kick app https://kick.com/settings/developer you need provide an URL.

These url likes to: https://www.mywebhooklistener.com/api/webhook

You need create an endpoint to recive the webhooks.

```csharp
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
    void Events_OnLivestreamStatusUpdated(object? sender, LivestreamStatusUpdatedEventArgs e)
    {
        _logger.LogInformation("OnLivestreamStatusUpdated: {@data}", e.Data);  // Log the event data
    }

    // Event handler for the OnChannelSubscriptionRenewal event
    void Events_OnChannelSubscriptionRenewal(object? sender, ChannelSubscriptionRenewalEventArgs e)
    {
        _logger.LogInformation("OnChannelSubscriptionRenewal: {@data}", e.Data);  // Log the event data
    }

    // Event handler for the OnChannelNewSubscription event
    void Events_OnChannelNewSubscription(object? sender, ChannelNewSubscriptionEventArgs e)
    {
        _logger.LogInformation("OnChannelNewSubscription: {@data}", e.Data);  // Log the event data
    }

    // Event handler for the OnChannelGiftedSubscription event
    void Events_OnChannelGiftedSubscription(object? sender, ChannelGiftedSubscriptionEventArgs e)
    {
        _logger.LogInformation("OnChannelGiftedSubscription: {@data}", e.Data);  // Log the event data
    }

    // Event handler for the OnChannelFollowed event
    void Events_OnChannelFollowed(object? sender, ChannelFollowedEventArgs e)
    {
        _logger.LogInformation("OnChannelFollowed: {@data}", e.Data);  // Log the event data
    }

    // Event handler for the OnChatMessageSent event
    void Events_OnChatMessageSent(object? sender, ChatMessageSentEventArgs e)
    {
        _logger.LogInformation("OnChatMessageSent: {@data}", e.Data);  // Log the event data
    }

    // This method will handle incoming POST requests to the 'api/webhookminimal' endpoint
    [HttpPost("webhook")]
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
```

##### Test Real WebHooks in localhost

You need to use ngrok https://ngrok.com/ for this test.

```
#To get a public URL pointing your local server.

ngrok http http://localhost:7121
```

Now, the program will show you a public URL. It Looks like: https://02e0-213-177-211-49.ngrok-free.app

You need provide it to kick, inside the app configuration: https://kick.com/settings/developer

Now you are available to recive the webhooks.

You can test it sending a message in the chat. You will see the info in the log.


##### Test Fake WebHooks in localhost

You can use Postman https://www.postman.com/ to send fake data while your app is listening webhooks.

[Fake data can be found here](https://github.com/Rubarez/KickNetLib/blob/master/docs/Kick%20Webhooks%20Fake%20Payloads.postman_collection.json). You can import the project into postman and use it.

**Important**: Be secure to set the **ValidateSender** to **false** in configuration file to test it

## Kick Desktop Tool :wrench:

<p align="center"> 
<img src="https://github.com/Rubarez/KickNetLib/blob/master/res/Desktop2.jpg" style="max-height: 250px !important;">
</p>

The project contains an application tool for Windows.

- [KickNetDesktopForms](https://github.com/Rubarez/KickNetLib/tree/master/src/KickNetLib/kickNetDesktopForms)

The application provide a simple interface to create an access token, refresh it, revoke it, and finally test the API and Webhooks.

For test real Webhook you need to use ngrok https://ngrok.com/ for this test. And configure, in code (Desktop tool), the listener.

**IMPORTANT**: Check all kick app configurations https://kick.com/settings/developer to match URL with the desktop tool listeners.


## Disclaimer :runner:

By using the **KickNetLib** software, you agree to the following terms and conditions. This software is provided to you "as-is," without any guarantees or warranties of any kind, express or implied. The following terms apply to the fullest extent permitted by law:

Software Use: The software is provided for your use, but it is your responsibility to ensure that it is used appropriately and in accordance with applicable laws and regulations. We do not warrant that the software is error-free or will meet your specific requirements.

No Warranty: We provide no warranties, either express or implied, regarding the software. This includes, but is not limited to, warranties of merchantability, fitness for a particular purpose, accuracy, or non-infringement. We do not guarantee the software’s performance, availability, or functionality.

Risk of Use: You acknowledge and agree that you are using the software at your own risk. We are not responsible for any damage, loss of data, interruption of business, or any other damages or issues that may arise from using the software.

No Liability for Damages: In no event shall we be liable for any direct, indirect, incidental, special, consequential, or punitive damages arising out of the use of the software, even if we have been advised of the possibility of such damages. This includes, but is not limited to, data loss, system failure, or loss of profit.

Performance and Availability: We do not guarantee that the software will operate uninterrupted or error-free. We make no claims regarding the reliability or availability of the software at all times. We are not responsible for any downtime, disruptions, or failures that may occur.

Third-Party Software: The software may interact with or rely on third-party services or components, which are outside our control. We make no guarantees regarding the performance or reliability of such third-party services, and we disclaim all liability associated with them.

Modification and Updates: We reserve the right to modify, update, or discontinue the software at any time without notice. We do not commit to providing updates, fixes, or support for the software, and any future updates or modifications may alter its functionality.

No Support or Maintenance: We are under no obligation to provide support, maintenance, or troubleshooting for the software. Any support provided is at our discretion and may be limited.

Severability: If any provision of this disclaimer is held to be invalid or unenforceable by a court of competent jurisdiction, the remainder of the disclaimer will remain in full force and effect.

Acknowledgment: By using this software, you acknowledge that you have read, understood, and agree to be bound by this full disclaimer. If you do not agree with any part of this disclaimer, you must not use the software.

## License :scroll:

See [MIT License](LICENSE).


#### Fully developed by :computer:

:es: Rubén Álvarez Mel - Senior .Net developer
[Link to my Linkedin](https://es.linkedin.com/in/rub%C3%A9n-%C3%A1lvarez-mel-1838197a)