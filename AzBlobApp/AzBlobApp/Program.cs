using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Reflection.Metadata;

// cn from stacc10001 | Access key

string connectionString = "DefaultEndpointsProtocol=https;AccountName=stacc10001;AccountKey=abst_COPY_acc10001_Access key_xg==;EndpointSuffix=core.windows.net";

string containerName = $"scripts-{DateTime.Now:HH-MM-ss}";

//1. Creating a container

BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

//await blobServiceClient.CreateBlobContainerAsync(containerName); // access level = Private by default
await blobServiceClient.CreateBlobContainerAsync(containerName, PublicAccessType.Blob);

Console.WriteLine($"Container {containerName} created.");

//2. Uploading a Blob
string blobName = "script.sql";
string filePath = $"f:\\aztmp\\{blobName}";

BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);

BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

await blobClient.UploadAsync(filePath, overwrite: true);

Console.WriteLine($"Uploaded blob {blobName} to the container{containerName}");

//3. List Blobs

string ctName = "data";

BlobContainerClient blobContainerClientForListing = new BlobContainerClient(connectionString, ctName);
Console.WriteLine($"Blobs in {ctName} container:");
await foreach (BlobItem blobItem in blobContainerClientForListing.GetBlobsAsync())
{
    Console.WriteLine($"Blob name: {blobItem.Name}, Size: {blobItem.Properties.ContentLength} bytes, Tier: {blobItem.Properties.AccessTier}");
}
Console.WriteLine("End Of List");

//4. Downloading a Blob

//Get handle to a blob it-self
string directory = $"f:\\aztmp\\download-{containerName}\\";
string filePathToDownload = $"{directory}{blobName}";

BlobClient blobClient2 = new BlobClient(connectionString, containerName, blobName);

Directory.CreateDirectory(directory);
await blobClient2.DownloadToAsync(filePathToDownload);

//P.S. 
// was System.IO.DirectoryNotFoundException: 'Could not find a part of the path 'f:\aztmp\download\script.sql'.'
// According to the official ".NET" docs, you don't need to check if it exists first.
// Directory.CreateDirectory = Creates all directories and subdirectories in the specified path unless they already exist.

Console.WriteLine("Blob was downloaded");

await BlobHelper.AddBlobMetadataAsync(blobClient2);

Console.WriteLine($"Some metadata was added to {containerName} -> {blobName}");

await BlobHelper.ReadBlobMetadataAsync(blobClient2);


public static class BlobHelper
{
    public static async Task AddBlobMetadataAsync(BlobClient blob)
    {
        Console.WriteLine("Adding blob metadata...");

        try
        {
            IDictionary<string, string> metadata =
               new Dictionary<string, string>();

            // Add metadata to the dictionary by calling the Add method
            metadata.Add("docType", "textDocuments");

            // Add metadata to the dictionary by using key/value syntax
            metadata["category"] = "guidance";

            metadata["Department"] = "Logistics";

            // Set the blob's metadata.
            await blob.SetMetadataAsync(metadata);
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

    public static async Task ReadBlobMetadataAsync(BlobClient blob)
    {
        try
        {
            // Get the blob's properties and metadata.
            BlobProperties properties = await blob.GetPropertiesAsync();

            Console.WriteLine("Blob metadata:");

            // Enumerate the blob's metadata.
            foreach (var metadataItem in properties.Metadata)
            {
                Console.WriteLine($"\tKey: {metadataItem.Key}");
                Console.WriteLine($"\tValue: {metadataItem.Value}");
            }
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}

