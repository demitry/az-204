using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IEnumerable<string>? initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ');

builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
    .AddDownstreamWebApi("DownstreamApi", builder.Configuration.GetSection("DownstreamApi"))
    .AddInMemoryTokenCaches();


/*
warning CS0618: 'DownstreamWebApiExtensions.AddDownstreamWebApi(MicrosoftIdentityAppCallsWebApiAuthenticationBuilder, string, IConfiguration)' is obsolete: 'Use AddDownstreamApi in Microsoft.Identity.Abstractions, implemented in Microsoft.Identity.Web.DownstreamApi.See aka.ms/id-web-downstream-api-v2 for migration details.'
https://github.com/AzureAD/microsoft-identity-web/blob/master/docs/blog-posts/downstreamwebapi-to-downstreamapi.md
*/

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