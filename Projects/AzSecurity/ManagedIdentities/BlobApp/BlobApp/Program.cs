using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;

string blobURI = "https://stacc505050.blob.core.windows.net/mycontainer/myfile.txt";
string filePath = "C:\\tmp1\\myfile.txt";

TokenCredential tokenCredential = new DefaultAzureCredential();

BlobClient blobClient = new BlobClient(new Uri(blobURI), tokenCredential);

await blobClient.DownloadToAsync(filePath);

Console.WriteLine("The blob is downloaded");

