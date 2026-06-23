using Microsoft.AspNetCore.Http;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IFileServices
    {
        Task<string> SaveFileAsync(IFormFile file, string folderName);
        void DeleteFile(string filePath);
    }
}
