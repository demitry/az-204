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
        - [Add role assignments for UserA](#add-role-assignments-for-usera)
        - [Scope of the storage service](#scope-of-the-storage-service)
            - [[x] user_impersonation](#x-user_impersonation)
            - [[x] Access tokens used for implicit flows](#x-access-tokens-used-for-implicit-flows)
        - [Client secret](#client-secret)
        - [Get the access token](#get-the-access-token)
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
- [Microsoft Tutorial - WebApp](#microsoft-tutorial---webapp)
    - [Register an application with the Microsoft identity platform](#register-an-application-with-the-microsoft-identity-platform)
    - [Prepare an application for authentication](#prepare-an-application-for-authentication)
        - [Create project](#create-project)
        - [Create Certificate](#create-certificate)
        - [Upload Certificate](#upload-certificate)
        - [Configure the application for authentication and API reference](#configure-the-application-for-authentication-and-api-reference)
        - [Define the platform and URLs](#define-the-platform-and-urls)
    - [Add sign in to an application](#add-sign-in-to-an-application)
        - [Install identity packages - Microsoft.Identity.Web.UI](#install-identity-packages---microsoftidentitywebui)
        - [Implement authentication and acquire tokens](#implement-authentication-and-acquire-tokens)
        - [Result](#result)
        - [Is a certificate's thumbprint considered private?](#is-a-certificates-thumbprint-considered-private)
        - [Are Certificate Thumbprints Unique?](#are-certificate-thumbprints-unique)
        - [Migrating from DownstreamWebApi to DownstreamApi](#migrating-from-downstreamwebapi-to-downstreamapi)
        - [Program.cs With DownstreamApi](#programcs-with-downstreamapi)
        - [Using a Certificate For Deployment](#using-a-certificate-for-deployment)
        - [TODO:](#todo)
            - [Adam Freeman - Pro ASP.NET Core Identity Under the Hood with Authentication and Authorization in ASP.NET Core 5 and 6 Applications-Apress 2021](#adam-freeman---pro-aspnet-core-identity-under-the-hood-with-authentication-and-authorization-in-aspnet-core-5-and-6-applications-apress-2021)
            - [WebApi and MS Identity Authentication](#webapi-and-ms-identity-authentication)
            - [-229](#-229)

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

=> config signin and signout urls in package config and in AuthApp | Authentication
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

https://learn.microsoft.com/en-us/azure/active-directory/develop/microsoft-identity-web

Microsoft.Identity.Web.UI - Optional. Adds UI for user sign-in and sign-out and an associated controller for web apps.

```cs
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddMvcOptions(options => {
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddMicrosoftIdentityUI();

```

```cs
    //[Authorize] // no need
    public class IndexModel : PageModel
```

## Lab - ASP.NET - Adding Sign-in out - Part 2 [212]

Project - Add - New Scaffolded Item... - Identity - Add

Add identity
 - Account\Login
 - Account\Logout
 - AuthApp.Data.AuthAppContext
 - SQLite
 - Add

Support for ASP.NET Core Identity was added to your project.

For setup and configuration information, see https://go.microsoft.com/fwlink/?linkid=2116645.

## Lab - ASP.NET - Getting user claims [213]

Up to now - Authentication, it is based on OpenID protocol, which build on top on OAuth.

We checked - [x] ID tokens (used for implicit and hybrid flows)

so We can get user Claims - name-value pairs, info about user.

- aio
- http://schemas.microsoft.com/identity/claims/identityprovider
- name	Dmytro P
- http://schemas.microsoft.com/identity/claims/objectidentifier
- preferred_username	d***v@gmail.com
- rh
- http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier
- http://schemas.microsoft.com/identity/claims/tenantid
- uti

```html
<div class="text-center">
    <h1 class="display-4">Displaying all the claims</h1>
    <table class="table" table-dark">
        <thead>
            <tr>
                <th scope="col">Claim type</th>
                <th scope="col">Claim Value</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var _claim in ((ClaimsIdentity)User.Identity).Claims)
            {
                <tr>
                    <td>@_claim.Type</td>
                    <td>@_claim.Value</td>
                </tr>
            }
        </tbody>
    </table>
</div>
```

## Lab - Getting Group claims [214]

Default Directory

Groups | All groups

New Group
- Owners
- No owners selected
- Members
- Add members

AuthApp | Token configuration

Edit groups claims
[x] Security groups

Document has all properties fo an application object

AuthApp | Manifest

"groupMembershipClaims": "SecurityGroup" (it was null)

login with
usera@dpoluektovgmail.onmicrosoft.com

GroupA | Properties
Object Id : 8c8...e

- aio
- cc
- groups	8c8...e (Could be multiple groups)
- name	UserA
- http://schemas.microsoft.com/identity/claims/objectidentifier
- preferred_username	UserA@dpoluektovgmail.onmicrosoft.com
- rh
- http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier	
- http://schemas.microsoft.com/identity/claims/tenantid
- uti

## Lab - Getting other claims [215]

AuthApp | Token configuration

Add optional claim

Token type: ID

Access and ID tokens are used by applications for authentication
[x] email
[x] given_name

Add

[x] Turn on the Microsoft Graph ...(require for claims to appear in  token) 

Users UserA - you can change properties

## Lab - Getting an access token [216]

### Add role assignments for UserA

Get the access token and ensure that user has access to the storage account  

stacc505050 | Access Control (IAM)

Role assignments

UserA

no role assignment

Add - Role assignment - Role Reader - Next - Select Members - UserA

Failed, already exists

Storage Blob Data Reader - Successfully added

### Scope of the storage service

User -> App -> Storage Account

We are not giving access to App, we are giving access to User.

#### [x] user_impersonation

AuthApp | API permissions

Add a permission (Request API permissions) - Azure storage (https://storage.azure.com/)

[x] user_impersonation

Application can impersonate the user based on permissions given to the user to get the access token to get the access to the storage API.

Not Granting consent.. => user will concent the permission

#### [x] Access tokens (used for implicit flows)

AuthApp | Authentication

[x] Access tokens (used for implicit flows)

### Client secret

AuthApp | Certificates & secrets

New client secret

appsettings.json + "ClientSecret": ""

### Get the access token

```cs
string ScopeUserImpersonation = "user_impersonation";

string[] scope = new string[] { $"https://storage.azure.com/{ScopeUserImpersonation}" };

builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi(scope)
    .AddInMemoryTokenCaches();
```

```cs
        public async Task OnGet()
        {
            string ScopeUserImpersonation = "user_impersonation";
            string[] scope = new string[] { $"https://storage.azure.com/{ScopeUserImpersonation}" };

            accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scope);
        }
```

## Lab - Using an access token [217]

Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation

## Lab - Publishing onto Azure Web Apps [218]

webapp10001
Web App

Default domain
webapp10001.azurewebsites.net

AuthApp | Authentication

https://localhost:7236/signout-oidc

dpoluektovgmail.onmicrosoft.com

Re-New Subscription

https://webapp10001.azurewebsites.net/signin-oidc -> 

https://authapp20230509005058.azurewebsites.net/signin-oid

AuthApp | Authentication

- authapp20230509005058.azurewebsites.net
- https://authapp20230509005058.azurewebsites.net/signin-oidc
- https://authapp20230509005058.azurewebsites.net/signout-oidc

```
An unhandled exception occurred while processing the request.
MsalUiRequiredException: No account or login hint was passed to the AcquireTokenSilent call.
Microsoft.Identity.Client.Internal.Requests.Silent.SilentRequest.ExecuteAsync(CancellationToken cancellationToken)

MicrosoftIdentityWebChallengeUserException: IDW10502: An MsalUiRequiredException was thrown due to a challenge for the user. See https://aka.ms/ms-id-web/ca_incremental-consent.
Microsoft.Identity.Web.TokenAcquisition.GetAuthenticationResultForUserAsync(IEnumerable<string> scopes, string authenticationScheme, string tenantId, string userFlow, ClaimsPrincipal user, TokenAcquisitionOptions tokenAcquisitionOptions)
```

```
Error.
An error occurred while processing your request.
Request ID: 00-f6d95b0a108c9d4cb2be201ab2181975-9fa802eb85cdec4e-00

Development Mode
Swapping to the Development environment displays detailed information about the error that occurred.

The Development environment shouldn't be enabled for deployed applications. It can result in displaying sensitive information from exceptions to end users. For local debugging, enable the Development environment by setting the ASPNETCORE_ENVIRONMENT environment variable to Development and restarting the app.
```
Disable //"ASPNETCORE_ENVIRONMENT": "Development", in launchConfig.json

Switch to Production

- "ASPNETCORE_ENVIRONMENT": "Production",
- //"ASPNETCORE_ENVIRONMENT": "Development",


```cs
app.UseDeveloperExceptionPage();
```

Warning CS0618: 'TokenAcquisitionTokenCredential' is obsolete: 'Rather use TokenAcquirerTokenCredential'

```
An unhandled exception occurred while processing the request.
MsalUiRequiredException: No account or login hint was passed to the AcquireTokenSilent call.
Microsoft.Identity.Client.Internal.Requests.Silent.SilentRequest.ExecuteAsync(CancellationToken cancellationToken)

MicrosoftIdentityWebChallengeUserException: IDW10502: An MsalUiRequiredException was thrown due to a challenge for the user. See https://aka.ms/ms-id-web/ca_incremental-consent.
Microsoft.Identity.Web.TokenAcquisition.GetAuthenticationResultForUserAsync(IEnumerable<string> scopes, string authenticationScheme, string tenantId, string userFlow, ClaimsPrincipal user, TokenAcquisitionOptions tokenAcquisitionOptions)

```

https://localhost:7236/

```
An unhandled exception occurred while processing the request.
MsalUiRequiredException: No account or login hint was passed to the AcquireTokenSilent call.
Microsoft.Identity.Client.Internal.Requests.Silent.SilentRequest.ExecuteAsync(CancellationToken cancellationToken)

MicrosoftIdentityWebChallengeUserException: IDW10502: An MsalUiRequiredException was thrown due to a challenge for the user. See https://aka.ms/ms-id-web/ca_incremental-consent.
Microsoft.Identity.Web.TokenAcquisition.GetAuthenticationResultForUserAsync(IEnumerable<string> scopes, string authenticationScheme, string tenantId, string userFlow, ClaimsPrincipal user, TokenAcquisitionOptions tokenAcquisitionOptions)
```


Starting June 30th, 2020 we will no longer add any new features to Azure Active Directory Authentication Library (ADAL) and Azure AD Graph. We will continue to provide technical support and security updates but we will no longer provide feature updates. Applications will need to be upgraded to Microsoft Authentication Library (MSAL) and Microsoft Graph.


MsalUiRequiredException: No account or login hint was passed to the AcquireTokenSilent call.

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


# Microsoft Tutorial - WebApp

<https://learn.microsoft.com/en-us/azure/active-directory/develop/web-app-tutorial-01-register-application>

## Register an application with the Microsoft identity platform

App registrations > New registration.
- NewAuthApp
- Accounts in this organizational directory only
- Redirect URI (optional) will be configured at a later stage.
- Register

Display name NewAuthApp
- Application (client) ID     5dae781d-a2e1-4a25-b385-9bbb81be86ad
- Object ID                   c98088f1-6cc0-4dd7-8610-f23e5b957ddb
- Directory (tenant) ID       87349d34-316a-481c-ab12-5f5c7af3cd99

## Prepare an application for authentication

### Create project

- Open Visual Studio, and then select Create a new project.
- Search for and choose the ASP.NET Core Web App template, and then select Next.
- Enter a name for the project, such as NewWebAppLocal.
- Choose a location for the project or accept the default option, and then select Next.
- Accept the default for the Framework, Authentication type, and Configure for HTTPS. Authentication type can be set to none as this tutorial will cover this process.
- Select Create.

### Create Certificate

dotnet dev-certs https -ep ./certificate.crt --trust

```
dotnet dev-certs https -ep ./certificate.crt --trust
Failed to read environment variable [DOTNET_STARTUP_HOOKS], HRESULT: 0x800700CB
Failed to read environment variable [DOTNET_STARTUP_HOOKS], HRESULT: 0x800700CB
Trusting the HTTPS development certificate was requested. A confirmation prompt will be displayed if the certificate was not previously trusted. Click yes on the prompt to trust the certificate.
Successfully trusted the existing HTTPS certificate.
```

### Upload Certificate

NewAuthApp | Certificates & secrets

Certificates (0)

Upload certificate

NewAuthAppCertificate

NewAuthAppCertificate

**Record the Thumbprint value**, which will be used in the next step.

Certificate ID 1da3fc9d-c41a-474f-a3f6-3b71076e1dc1

Thumbprint D5699FAE3CCBB3E938AED0CC724B24C28CB9548C

### Configure the application for authentication and API reference

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "TenantId": "Enter the tenant ID obtained from the Azure portal",
    "ClientId": "Enter the client ID obtained from the Azure portal",
    "ClientCertificates": [
      {
        "SourceType": "StoreWithThumbprint",
        "CertificateStorePath": "CurrentUser/My",
        "CertificateThumbprint": "Enter the certificate thumbprint obtained from the Azure portal"
      }   
    ],
    "CallbackPath": "/signin-oidc"
  },
  "DownstreamApi": {
    "BaseUrl": "https://graph.microsoft.com/v1.0/me",
    "Scopes": "user.read"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

- Instance - The authentication endpoint. Check with the different available endpoints in National clouds.
- TenantId - The identifier of the tenant where the application is registered. Replace the text in quotes with the Directory (tenant) ID value that was recorded earlier from the overview page of the registered application.
- ClientId - The identifier of the application, also referred to as the client. Replace the text in quotes with the Application (client) ID value that was recorded earlier from the overview page of the registered application.
- ClientCertificates - A self-signed certificate is used for authentication in the application. Replace the text of the CertificateThumbprint with the thumbprint of the certificate that was previously recorded.
- CallbackPath - Is an identifier to help the server redirect a response to the appropriate application.
- DownstreamApi - Is an identifier that defines an endpoint for accessing Microsoft Graph. The application URI is combined with the specified scope. To define the configuration for an application owned by the organization, the value of the Scopes attribute is slightly different.

Save changes to the file.

In the Properties folder, open the launchSettings.json file.

Find and record the https value applicationURI within launchSettings.json, for example https://localhost:{port}. This URL will be used when defining the Redirect URI.

```json
"applicationUrl": "https://localhost:7273;
```

### Define the platform and URLs

NewAuthApp | Authentication

Add platform - Web

 - Under Redirect URIs, enter the applicationURL and the CallbackPath, /signin-oidc, in the form of https://localhost:{port}/signin-oidc.

 - Under Front-channel logout URL, enter the following URL for signing out, https://localhost:{port}/signout-oidc.

https://localhost:7273/signin-oidc

https://localhost:7273/signout-oidc

Select Configure.

## Add sign in to an application

### Install identity packages - Microsoft.Identity.Web.UI

### Implement authentication and acquire tokens

```cs
// <ms_docref_import_types>
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
// </ms_docref_import_types>

// <ms_docref_add_msal>
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IEnumerable<string>? initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ');

builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
        .AddDownstreamWebApi("DownstreamApi", builder.Configuration.GetSection("DownstreamApi"))
        .AddInMemoryTokenCaches();
// </ms_docref_add_msal>

// <ms_docref_add_default_controller_for_sign-in-out>
builder.Services.AddRazorPages().AddMvcOptions(options =>
    {
        var policy = new AuthorizationPolicyBuilder()
                      .RequireAuthenticatedUser()
                      .Build();
        options.Filters.Add(new AuthorizeFilter(policy));
    }).AddMicrosoftIdentityUI();
// </ms_docref_add_default_controller_for_sign-in-out>

// <ms_docref_enable_authz_capabilities>
WebApplication app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// </ms_docref_enable_authz_capabilities>

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.Run();
```

### Result

Before rendering the page, the Page Model was able to make a call to Microsoft Graph's /me API for your user and received the following:

```json
{
  "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users/$entity",
  "businessPhones": [],
  "displayName": "Dmytro Poluektov",
  "givenName": "Dmytro",
  "jobTitle": null,
  "mail": null,
  "mobilePhone": null,
  "officeLocation": null,
  "preferredLanguage": null,
  "surname": "Poluektov",
  "userPrincipalName": "dpoluektov_gmail.com#EXT#@dpoluektovgmail.onmicrosoft.com",
  "id": "a6ef4cf0-3753-4433-9536-21a9f6a8e22a"
}
```

Refreshing this page will continue to use the cached access token acquired for Microsoft Graph, which is valid for future page views will attempt to refresh this token as it nears its expiration.

### Is a certificate's thumbprint considered private?

https://security.stackexchange.com/questions/186754/is-a-certificates-thumbprint-considered-private

No, thumbprint is not considered private. This is because, thumbprint is a result of one-way hashing function (SHA1 or other).

By definition, hashing functions accepts messages of variable length as input and produce fixed-length output. Output length depends on actual hashing function. As the result, it is virtually impossible to recover input message by knowing only it's hash (thumbprint).

Please note, that there are several types of attacks against hashes (for example, preimage attack) which allow you to find another input that produces same hash value (hash collision). This means that using such attacks you can get N number of inputs that produce particular hash. However, you cannot know which exactly of these inputs in N was in mind to calculate particular hash. Any of element in N could be. This means that you can spoof the thumbprint (although computationally difficult), but you cannot recover exact input, only possible candidates.

So, you can post thumbprint value in public when necessary without worrying that someone will recover input message that produced specified thumbprint.

### Are Certificate Thumbprints Unique?

https://www.microsoft.com/en-us/research/publication/are-certificate-thumbprints-unique/

A certificate thumbprint is a hash of a certificate, computed over all certificate data and its signature. Thumbprints are used as unique identifiers for certificates, in applications when making trust decisions, in configuration files, and displayed in interfaces. In this paper we show that thumbprints are not unique in two cases. First, we demonstrate that creating two X.509 certificates with the same thumbprint is possible when the hash function is weak, in particular when chosen-prefix collision attacks are possible. This type of collision attack is now practical for MD5, and expected to be practical for SHA-1 in the near future. Second, we show that certificates may be mauled in a way that they remain valid, but that they have different thumbprints. While these properties may be unexpected, we believe the scenarios where this could lead to a practical attack are limited and require very sophisticated attackers. We also checked the thumbprints of a large dataset of certificates used on the Internet, and found no evidence that would indicate thumbprints of certificates in use today are not unique.

### Migrating from DownstreamWebApi to DownstreamApi

```cs
/*
warning CS0618: 'DownstreamWebApiExtensions.AddDownstreamWebApi(MicrosoftIdentityAppCallsWebApiAuthenticationBuilder, string, IConfiguration)' is obsolete: 'Use AddDownstreamApi in Microsoft.Identity.Abstractions, implemented in Microsoft.Identity.Web.DownstreamApi.See aka.ms/id-web-downstream-api-v2 for migration details.'
*/
```

https://github.com/AzureAD/microsoft-identity-web/blob/master/docs/blog-posts/downstreamwebapi-to-downstreamapi.md

Microsoft.Identity.Web 1.x had introduced an interface IDownstreamWebApi that called an API taking care of the authentication details (getting the token, adding the authorization header, ...). This interface grew organically based on your feature requests, and it became obvious that we needed to make public API breaking changes to enable all the scenarios you have asked for over the past couple of years.

Rather than changing this existing API, the Microsoft.Identity.Web team has decided to build another interface, taking into account all your feedback. IDownstreamApi was born. We've deprecated the old interface, and the future efforts will be on the new implementation, but this choice should give you time to migrate if you choose to do so.

This article explains:

how to migrate from IDownstreamWebApi to IDownstreamApi
what are the differences between IDownstreamWebApi and IDownstreamApi
How to migrate from IDownstreamWebApi and IDownstreamApi
To migrate your existing code using IDownstreamWebApi to Microsoft.Identity.Web 2.x and IDownstreamApi you will need to:

- add a reference to the Microsoft.Identity.Web.DownstreamApi NuGet package

- in the code doing the initialization of the application (usually startup.cs or program.cs) replace:

```cs
.AddDownstreamWebApi("serviceName", Configuration.GetSection("SectionName"))
```

by

```cs
.AddDownstreamApi("serviceName", Configuration.GetSection("SectionName"))
```

in the configuration file (appsettings.json), in the section representing the downstream web API, change the Scopes value from being a string to being an array of strings:

```json
"DownstreamApi1": {
    "BaseUrl": "https://myapi.domain.com",
    "Scopes": "https://myapi.domain.com/read  https://myapi.domain.com/write"
},  
```

becomes

```json
"DownstreamApi1": {
    "BaseUrl": "https://myapi.domain.com",
    "Scopes": [
        "https://myapi.domain.com/read",
        "https://myapi.domain.com/write" 
    ]
}, 
```
 
[!WARNING] If you forget to change the Scopes to an array, when you try to use the IDownstreamApi the scopes will appear null, and IDownstreamApi will attempt an anonymous (unauthenticated) call to the downstream API, which will result in a 401/unauthenticated.

in the controller:

- add **using namespace Microsoft.Identity.Abstractions**
- inject IDownstreamApi instead of IDownstreamWebApi
- Replace CallWebApiForUserAsync by CallApiForUserAsync

if you were using one of the method GetForUser, PutForUser, PostForUser, change the string that was expressing the relative path, to a delegate setting this relative path:

```cs
 Todo value = await _downstreamWebApi.GetForUserAsync<Todo>(ServiceName, $"api/todolist/{id}");
```

becomes

```cs
 Todo value = await _downstreamWebApi.GetForUserAsync<Todo>(
      ServiceName,
      options => options.RelativePath = $"api/todolist/{id}";);
```

### Program.cs With DownstreamApi

```cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IEnumerable<string>? initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ');

builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
    .AddDownstreamApi("DownstreamApi", builder.Configuration.GetSection("DownstreamApi"))
    .AddInMemoryTokenCaches();

builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddMicrosoftIdentityUI();


WebApplication app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.Run();
```

newauthapplocal.azurewebsites.net

NewAuthApp | Authentication
https://localhost:7273/signin-oidc
https://localhost:7273/signout-oidc

newauthapplocal.azurewebsites.net

https://newauthapplocal.azurewebsites.net/signin-oidc
https://newauthapplocal.azurewebsites.net/signout-oidc

This page isn’t working newauthapplocal.azurewebsites.net is currently unable to handle this request.
HTTP ERROR 500

```cs
app.UseDeveloperExceptionPage();
```

```
ArgumentException: IDW10109: All client certificates passed to the configuration have expired or can't be loaded. (Parameter 'clientCredentials')
```

### Using a Certificate For Deployment

The .NET test certificate can be used only during development, and you will need to use a real certificate when you are ready to deploy a project. If you don’t have a certificate, I recommend https://letsencrypt.org/, which is a nonprofit organization that issues certificates for free. As part of the registration process, you will need to prove you control the domain for which you require a certificate, but Let’s Encrypt provides tools for this process.

Once you have a certificate—regardless of how you obtain one—you can find instructions for configuring ASP.NET Core at https://docs.microsoft.com/en-us/aspnet/core/security/authentication/certauth?view=aspnetcore-5.0.

### TODO:

#### Adam Freeman - Pro ASP.NET Core Identity Under the Hood with Authentication and Authorization in ASP.NET Core 5 and 6 Applications-Apress (2021)

<https://github.com/Apress/pro-asp.net-core-identity>

#### WebApi and MS Identity Authentication

<https://learn.microsoft.com/en-us/azure/active-directory/develop/web-api-quickstart?pivots=devlang-aspnet>

#### 220-229

- 220. Lab - Creating our Web API
- 221. Lab - Let's publish our Web API
- 222. Lab - Protecting our Web API - Application Registration
- 223. Lab - Protecting our Web API - Code Configuration
- 224. Lab - Calling our protected Web API from POSTMAN
- 225. Lab - Invoking the Web API from a Console application
- 226. Lab - Invoking the Web API from a Web App
- 227. Lab - App Role claims
- 228. Note on Token Validation
- 229. Delete your application objects in Azure AD
- Assignment 6: Assignment - Web Application - Using Graph API
