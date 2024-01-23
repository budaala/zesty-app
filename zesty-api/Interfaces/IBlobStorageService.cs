namespace zesty_api.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> UploadFile(IFormFile file);
        Task DeleteFile(string fileUrl);
    }
}
