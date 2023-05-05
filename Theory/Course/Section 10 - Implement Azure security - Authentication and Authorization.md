<!-- TOC -->

- [Section 10: Implement Azure security - Authentication and Authorization](#section-10-implement-azure-security---authentication-and-authorization)
    - [What are we going to cover [202]](#what-are-we-going-to-cover-202)
    - [Authentication and Authorization [203]](#authentication-and-authorization-203)
    - [API's and Authorization [204]](#apis-and-authorization-204)
    - [Using Microsoft libraries [205]](#using-microsoft-libraries-205)
    - [OAuth2 - Authorization Code Grant - Initial Understanding [206]](#oauth2---authorization-code-grant---initial-understanding-206)
        - [OAuth 2.0 authorization process](#oauth-20-authorization-process)
    - [OAuth2 - Authorization Code Grant - More details [207]](#oauth2---authorization-code-grant---more-details-207)
    - [Review on what we have done so far [208]](#review-on-what-we-have-done-so-far-208)
    - [OAuth while logging into Azure [209]](#oauth-while-logging-into-azure-209)
    - [Lab - ASP.NET - Adding Authentication [210]](#lab---aspnet---adding-authentication-210)
    - [Lab - ASP.NET - Adding Sign-in out - Part 1 [211]](#lab---aspnet---adding-sign-in-out---part-1-211)
    - [Lab - ASP.NET - Adding Sign-in out - Part 2 [212]](#lab---aspnet---adding-sign-in-out---part-2-212)
    - [Lab - ASP.NET - Getting user claims [213]](#lab---aspnet---getting-user-claims-213)
    - [Lab - Getting Group claims [214]](#lab---getting-group-claims-214)
    - [Lab - Getting other claims [215]](#lab---getting-other-claims-215)
    - [Lab - Getting an access token [216]](#lab---getting-an-access-token-216)
    - [Lab - Using an access token [217]](#lab---using-an-access-token-217)
    - [Lab - Publishing onto Azure Web Apps [218]](#lab---publishing-onto-azure-web-apps-218)
    - [Lab - Accessing Blob Storage via POSTMAN [219]](#lab---accessing-blob-storage-via-postman-219)
    - [Lab - Creating our Web API [220]](#lab---creating-our-web-api-220)
    - [Lab - Let's publish our Web API [221]](#lab---lets-publish-our-web-api-221)
    - [Lab - Protecting our Web API - Application Registration [222]](#lab---protecting-our-web-api---application-registration-222)
    - [Lab - Protecting our Web API - Code Configuration [223]](#lab---protecting-our-web-api---code-configuration-223)
    - [Lab - Calling our protected Web API from POSTMAN [224]](#lab---calling-our-protected-web-api-from-postman-224)
    - [Lab - Invoking the Web API from a Console application [225]](#lab---invoking-the-web-api-from-a-console-application-225)
    - [Lab - Invoking the Web API from a Web App [226]](#lab---invoking-the-web-api-from-a-web-app-226)
    - [Lab - App Role claims [227]](#lab---app-role-claims-227)
    - [Note on Token Validation [228]](#note-on-token-validation-228)
    - [Delete your application objects in Azure AD [229]](#delete-your-application-objects-in-azure-ad-229)
    - [Assignment 6: Assignment - Web Application - Using Graph API](#assignment-6-assignment---web-application---using-graph-api)

<!-- /TOC -->

# Section 10: Implement Azure security - Authentication and Authorization

## What are we going to cover [202]

## Authentication and Authorization [203]

Authentication - the process wherein you **prove that you are who you say you are**

Authorization - the process of **granting access** to perform an action.

**Old era**

User <-> app <-> DB <-> Resources

Problems:

1. You have to maintain the database of user names and passwords

2. You have to maintain the security of the database

3. You need to implement newer methods of authentication - MFA (Multi-Factor Authentication)

4. The application itself is responsible for authenticating the user.

## API's and Authorization [204]

1. Delegate the task of authentication to an external identity provider (AD).

2. The provider can take care of additional authentication mechanisms (MFA)

**API**

User - App - API (get customer/product/order info...) - DB

API - code is isolated

Multiple apps can access API (not embed this code)

User - App - API (get customer/product/order info...) - DB

API must authorize our user to access uor data.

Authorization.

App -> Identity Provider sends password to API

Generate/send the access token - API can decide - five access.

Life time - 60-90 min.

The API can validate the token based on the aud claims

## Using Microsoft libraries [205]

Microsoft Identity PLatform

- Connect using different identity providers

- Social accounts

- OAuth2.0 and OpenID Connect standards

Microsoft Authentication Library

- Acquire access tokens from the Microsoft Identity platform

- This can be used to authenticate users and allow secure access to API's

- Maintains the token cache and refresh tokens when they are about to expire.

## OAuth2 - Authorization Code Grant - Initial Understanding [206]

OAuth 2.0 - Industry-standard protocol for authorization

- Login to /NET Web App

- User defined in Azure AD

- App authenticate the user

- User has permissions to view images in storage

- Application will take users permission and access storage account

<https://oauth.net/>

<https://oauth.net/getting-started/>

<https://habr.com/ru/companies/vk/articles/115163/>

User (Resource owner) - the user who has access to the protected resource

Client - Application requesting access to the protected resource

### OAuth 2.0 authorization process

- **Client Registration**: The client (the application requesting access to a user's resources) registers itself with the authorization server. During registration, the client obtains a client identifier and, optionally, a client secret.

- **User Authorization Request**: The client initiates the authorization process by redirecting the user to the authorization server. The client includes the client identifier, the requested scope of access, and a redirect URI where the user will be redirected after authorization.

- **User Consent**: At the authorization server, the user is presented with a consent screen that explains the permissions requested by the client. The user has the option to grant or deny access to their resources.

- **Authorization Grant**: If the user grants access, the authorization server issues an authorization grant to the client. The type of grant issued depends on the specific OAuth 2.0 flow being used. Common grant types include authorization code, implicit, resource owner password credentials, and client credentials.

- **Access Token Request**: The client sends a request to the authorization server to exchange the authorization grant for an access token. The request includes the grant type, client identifier, client secret (if applicable), and the authorization grant.

- **Access Token Issuance**: The authorization server validates the request and, if successful, issues an access token to the client. The access token represents the client's authorization to access the requested resources.

- **Accessing Protected Resources**: The client includes the access token in subsequent requests to the resource server (API server) to access the protected resources. The access token serves as proof of authorization.

- **Token Expiration and Refresh**: Access tokens typically have a limited lifespan. When an access token expires, the client can use a refresh token (if provided) to obtain a new access token without involving the user again. The client sends a token refresh request to the authorization server to exchange the refresh token for a new access token.

## OAuth2 - Authorization Code Grant - More details [207]

Step 1. The application makes a call to the authorization server which has the authorization code. At this time we are not getting the access token.

Step 2. The authorization server sends the authorization code to the application.
    - The auth code is just the initial step in the process. The app can't do much with this code.
    - The application then needs to use the authorization code to get the access token. The authorization code is viewable in the browser.
    - But the latter on process of getting the access token with the use of the authorization code is done by the application in the backend (you will not see it in the browser).

Step 3. The application requests for an access token. The access token will have the permissions of the user.

Step 4. The web app will ask the resource server for access to the resource.

## Review on what we have done so far [208]

BlobApp

```csharp
string connectionString = "DefaultEndpointsProtocol=https;AccountName=stacc10001;AccountKey=abst_COPY_acc10001_Access key_xg==;EndpointSuffix=core.windows.net";
```

Problem:

AccountKey - "master" key, allow perform any operation within the storage account

Access via:

- Account Key
- Application object + Managed identity (better security)
access to app object: ClientSecretCredentials class, client secret
- Postman - Graph API access token, grant_type: client_credentials outside the context of the user (we are not logged in as a user, just a client application)
this was client credentials grant flow

OAuth - protocol ans set of standards about how clients can authorize themselves to access the resource.

Access API: Each service in azure platform has API.

## OAuth while logging into Azure [209]

<https://portal.azure.com/>

sign in

```text
https://login.microsoftonline.com/organizations/oauth2/v2.0/authorize?redirect_uri= 
&response_type= code... 
&state=OpenIdConnect.AuthenticationProperties 
&response_mode=form_post 
&nonce= 
&client-request-id= 
&x-client-SKU=
```

oauth2 - authorize - to sign in

```text
https://login.live.com/oauth20_authorize.srf?scope=openid+profile+email+offline_access&response_type=code...
```

response_type=code - initialize an exchange, code grant flow

## Lab - ASP.NET - Adding Authentication [210]

AuthApp initial

App registrations - New registration - AuthApp - Register

Integrate with app

appsettings.json - add


```json
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "TenantId": "87349d34-316a-481c-ab12-5f5c7af3cd99", //AuthApp registration - Directory (tenant) ID
    "ClientId": "a8084fa2-4e6a-4ec5-a599-de584d8f565e" //AuthApp registration - Application (client) ID
  }
```

nuget Microsoft.Identity.Web

Program.cs

```cs
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

# ------------------------------------------------------
# NOTICE: AddMicrosoftIdentityWebAppAuthentication
# ------------------------------------------------------
builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
# ------------------------
# NOTICE: Use MS Auth
# ------------------------
app.UseAuthentication(); // Now use MS Auth
app.UseAuthorization();

app.MapRazorPages();

app.Run();

```

If we want to access the index page - we need to authorize => add  [Authorize]

```cs
namespace AuthApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
```

AuthApp | Authentication

Add Platform

Web

- Redirect URIs - after auth has taken place => redirect, go back to app
- Check [x] ID tokens (used for implicit and hybrid flows)
- "Configure"

AuthApp | API permissions

```
Microsoft Graph (1)
User.Read
Delegated
Sign in and read user profile
```

Previously we added application type permissions (login without the user)

This is **Delegated type permissions**

- login with user defined in Azure AD, so take permissions of the user
- This is consent screen

Remember "Grant admin consent for Default Directory" ? with Postman? With Postman we are not logged in, no ability, we are NOT "Grant admin consent for Default Directory".

- Can we access on your behalf ? Can we access your profile info?

Accept

```
Sorry, but we’re having trouble signing you in.

AADSTS50011: The redirect URI 'https://localhost:7236/signin-oidc' specified in the request does not match the redirect URIs configured for the application 'a8084fa2-4e6a-4ec5-a599-de584d8f565e'. Make sure the redirect URI sent in the request matches one added to your application in the Azure portal. Navigate to https://aka.ms/redirectUriMismatchError to learn more about how to fix this.
```

=> cofig signin and signout urls in package config and in AuthApp | Authentication
 settings.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "TenantId": "87349d34-316a-481c-ab12-5f5c7af3cd99", //AuthApp registration - Directory (tenant) ID
    "ClientId": "a8084fa2-4e6a-4ec5-a599-de584d8f565e", //AuthApp registration - Application (client) ID
    "CallbackPath": "/signin-oidc",                     // check AuthApp | Authentication - Redirect URIs
    "SignedOutCallbackPath": "/signout-oidc"            // check AuthApp | Authentication - Front-channel logout URL
  }
}

```

AuthApp | Authentication

Redirect URIs: https://localhost:7236/signin-oidc

Front-channel logout URL: https://localhost:7236/signout-oidc

Protocols Built on OAuth 2.0 - OpenID Connect (OpenID Foundation)

https://openid.net/connect/

MS used OpenID for authentication

and then used OAuth for authorization

We used [x] **ID tokens** (used for implicit and hybrid flows) - for OpenId connect

Otherwise you will fail to authenticate to Azure AD.

Redirect URIs

The URIs we will accept as destinations when returning authentication responses (tokens) after successfully authenticating or signing out users. The redirect URI you send in the request to the login server should match one listed here. Also referred to as reply URLs. Learn more about Redirect URIs and their restrictions

## Lab - ASP.NET - Adding Sign-in out - Part 1 [211]
## Lab - ASP.NET - Adding Sign-in out - Part 2 [212]
## Lab - ASP.NET - Getting user claims [213]
## Lab - Getting Group claims [214]
## Lab - Getting other claims [215]
## Lab - Getting an access token [216]
## Lab - Using an access token [217]
## Lab - Publishing onto Azure Web Apps [218]
## Lab - Accessing Blob Storage via POSTMAN [219]
## Lab - Creating our Web API [220]
## Lab - Let's publish our Web API [221]
## Lab - Protecting our Web API - Application Registration [222]
## Lab - Protecting our Web API - Code Configuration [223]
## Lab - Calling our protected Web API from POSTMAN [224]
## Lab - Invoking the Web API from a Console application [225]
## Lab - Invoking the Web API from a Web App [226]
## Lab - App Role claims [227]
## Note on Token Validation [228]
## Delete your application objects in Azure AD [229]
## Assignment 6: Assignment - Web Application - Using Graph API
