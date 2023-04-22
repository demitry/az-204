using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Diagnostics.CodeAnalysis;

public static class BlobHelper
{
    public static async Task AddBlobMetadataAsync(BlobClient blob)
    {
        Console.WriteLine("Adding blob meta-data...");

        try
        {
            IDictionary<string, string> metadata =
               new Dictionary<string, string>();

            // Add meta-data to the dictionary by calling the Add method
            metadata.Add("docType", "textDocuments");

            // Add meta-data to the dictionary by using key/value syntax
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

    public static async Task SetBlobMetadataAsync(BlobClient blob, IDictionary<string, string> metadata, BlobRequestConditions blobRequestConditions = null)
    {
        Console.WriteLine("Adding blob meta-data...");

        try
        {
            await blob.SetMetadataAsync(metadata, blobRequestConditions);
        }
        catch (RequestFailedException e)
        {
            Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

    public static async Task SetBlobMetadataAsync(BlobClient blob, IDictionary<string, string> metadata, string leaseId)
    {
        BlobRequestConditions blobRequestConditions = new BlobRequestConditions
        {
            LeaseId = leaseId
        };
        
        await SetBlobMetadataAsync(blob, metadata, blobRequestConditions);
    }

    public static async Task ReadBlobMetadataAsync(BlobClient blob)
    {
        try
        {
            // Get the blob's properties and meta-data.
            BlobProperties properties = await blob.GetPropertiesAsync();

            Console.WriteLine("Blob meta-data:");

            // Enumerate the blob's meta-data.
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

