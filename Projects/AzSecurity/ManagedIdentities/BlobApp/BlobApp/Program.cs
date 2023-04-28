using Azure.Identity;
using Azure.Storage.Blobs;

string tenantId = "87349d34-316a-481c-ab12-5f5c7af3cd99";
string clientId = "45c63e12-a365-4dea-bb53-79e516131d8a";
string clientSecret = "R1u8Q....9ucLf";

string blobURI = "https://stacc505050.blob.core.windows.net/mycontainer/myfile.txt";

string filePath = "F:\\aztmp\\myfile.txt";

ClientSecretCredential clientCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

BlobClient blobClient = new BlobClient(new Uri(blobURI),clientCredential);

await blobClient.DownloadToAsync(filePath);

Console.WriteLine("The blob is downloaded");

