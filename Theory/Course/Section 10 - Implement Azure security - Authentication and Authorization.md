<!-- TOC -->

- [Section 10: Implement Azure security - Authentication and Authorization](#section-10-implement-azure-security---authentication-and-authorization)
    - [What are we going to cover [202]](#what-are-we-going-to-cover-202)
    - [Authentication and Authorization [203]](#authentication-and-authorization-203)
    - [API's and Authorization [204]](#apis-and-authorization-204)
    - [Using Microsoft libraries [205]](#using-microsoft-libraries-205)
    - [OAuth2 - Authorization Code Grant - Initial Understanding [206]](#oauth2---authorization-code-grant---initial-understanding-206)
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
## Using Microsoft libraries [205]
## OAuth2 - Authorization Code Grant - Initial Understanding [206]
## OAuth2 - Authorization Code Grant - More details [207]
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
