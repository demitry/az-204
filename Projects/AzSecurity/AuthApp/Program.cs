/*
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AuthApp.Data;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthAppContextConnection"); ;

builder.Services.AddDbContext<AuthAppContext>(options =>
    options.UseSqlite(connectionString)); ;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthAppContext>(); ;

// Add services to the container.


//builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd");
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddMicrosoftIdentityUI();


// Add MSAL wrapper for web apps
builder.Services
    .AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddInMemoryTokenCaches();
// Below code is necessary and must come AFTER you add the identity service.  If you don't include this
// your ID token will be formatted as SAML claims instead of proper OAuth2 claims.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


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
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();


*/

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