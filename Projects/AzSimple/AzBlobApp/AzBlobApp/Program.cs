using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Reflection.Metadata;

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

Console.WriteLine($"Some meta-data was added to {containerName} -> {blobName}");

await BlobHelper.ReadBlobMetadataAsync(blobClient2);

//await JustAckLease();
await AckLeaseAndRelease();

async Task JustAckLease()
{
    BlobClient client = new BlobClient(connectionString, containerName, blobName);

    BlobLeaseClient blobLeaseClient = client.GetBlobLeaseClient();

    TimeSpan leaseTime = TimeSpan.FromSeconds(60);

    Console.WriteLine($"Acquiring {containerName} - {blobName} for {leaseTime} s.");
    Console.WriteLine($"Please test the resource, it should be not editable");
    //This blob has an active lease and can not be deleted or edited.
    
    Response<BlobLease> response = await blobLeaseClient.AcquireAsync(duration: leaseTime);
    
    Console.WriteLine($"Lease Id is: {response.Value.LeaseId}");
}

async Task AckLeaseAndRelease()
{
    BlobClient client = new BlobClient(connectionString, containerName, blobName);
    BlobLeaseClient blobLeaseClient = client.GetBlobLeaseClient();
    TimeSpan leaseTime = TimeSpan.FromSeconds(60);

    // Request a lease and set its duration
    Response<BlobLease> response = await blobLeaseClient.AcquireAsync(leaseTime);

    var metadata = new Dictionary<string, string>
    {
        { "lease1", "value1" }
    };


    //await BlobHelper.SetBlobMetadataAsync(client, metadata);  // X X X

    /*
     * Adding blob meta-data...
     * HTTP error code 412: LeaseIdMissing
     * There is currently a lease on the blob and no lease ID was specified in the request.
     *  Status: 412 (There is currently a lease on the blob and no lease ID was specified in the request.)
     */

    /* If you're unable to add metadata to the blob after acquiring the lease with AcquireAsync(), 
     * it's likely because the request to set metadata doesn't include the lease ID that was acquired with the lease.
     * To set blob metadata after acquiring the lease,
     * you'll need to include the lease ID in the BlobHttpHeaders object that's passed to the SetHttpHeadersAsync() method.
     */

    await BlobHelper.SetBlobMetadataAsync(client, metadata, response.Value.LeaseId);

    Console.WriteLine("Text successfully appended to the Append Blob!");

    // Release the lease
    await blobLeaseClient.ReleaseAsync();

    Console.WriteLine("Lease successfully acquired and released!");
}