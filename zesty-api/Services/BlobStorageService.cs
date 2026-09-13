using Azure.Storage.Blobs;
using zesty_api.Interfaces;

namespace zesty_api.Services;

public class BlobStorageService : IBlobStorageService
{
    private const string ContainerName = "zestyappimages";
    private readonly string? _connectionString;

    public BlobStorageService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("AzureBlobStorageConnection");
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        await using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, true);
        }

        var url = blobClient.Uri.ToString();

        return url;
    }

    public async Task DeleteFile(string fileUrl)
    {
        if (fileUrl == "https://zestyappblob.blob.core.windows.net/zestyappimages/placeholder.png") return;
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

        var fileName = Path.GetFileName(fileUrl);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        await blobClient.DeleteIfExistsAsync();
    }
}