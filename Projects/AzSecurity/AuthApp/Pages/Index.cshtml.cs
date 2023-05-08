using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;

namespace AuthApp.Pages
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ITokenAcquisition _tokenAcquisition;

        public string accessToken;

        public IndexModel(ILogger<IndexModel> logger, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task OnGet()
        {
            string ScopeUserImpersonation = "user_impersonation";

            string[] scope = new string[] { $"https://storage.azure.com/{ScopeUserImpersonation}" };

            accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scope);
        }
    }
}