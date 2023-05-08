using Azure.Storage.Blobs;
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

        public string blobContent;

        public IndexModel(ILogger<IndexModel> logger, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task OnGet()
        {
            
            //string ScopeUserImpersonation = "user_impersonation";
            //string[] scope = new string[] { $"https://storage.azure.com/{ScopeUserImpersonation}" };
            //accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scope);
            
            TokenAcquisitionTokenCredential tokenAcquisitionTokenCredential = new TokenAcquisitionTokenCredential(_tokenAcquisition);
            Uri blobUri = new Uri("https://stacc505050.blob.core.windows.net/mycontainer/myfile.txt");

            BlobClient blobClient = new BlobClient(blobUri, tokenAcquisitionTokenCredential);
            MemoryStream memoryStream = new MemoryStream();
            blobClient.DownloadTo(memoryStream);
            memoryStream.Position = 0;
            StreamReader streamReader = new StreamReader(memoryStream);
            blobContent = streamReader.ReadToEnd();
        }
    }
}