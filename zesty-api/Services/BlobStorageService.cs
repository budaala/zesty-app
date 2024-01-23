using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using zesty_api.Interfaces;

namespace zesty_api.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly string _connectionString;
        private readonly string _containerName = "zestyappimages";

        public BlobStorageService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("AzureBlobStorageConnection");
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            try
            {
                var blobServiceClient = new BlobServiceClient(_connectionString);
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var blobClient = blobContainerClient.GetBlobClient(fileName);

                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                var url = blobClient.Uri.ToString();

                return url;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task DeleteFile(string fileUrl)
        {
            try
            {
                var blobServiceClient = new BlobServiceClient(_connectionString);
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                var fileName = Path.GetFileName(fileUrl);
                var blobClient = blobContainerClient.GetBlobClient(fileName);

                await  blobClient.DeleteIfExistsAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
