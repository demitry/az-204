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

## Review on what we have done so far [208]
## OAuth while logging into Azure [209]
## Lab - ASP.NET - Adding Authentication [210]
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
