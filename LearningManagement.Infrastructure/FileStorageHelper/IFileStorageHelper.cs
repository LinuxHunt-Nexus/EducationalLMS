using Microsoft.AspNetCore.Http;

namespace LearningManagement.Infrastructure.ImageStorageHelper;

public interface IFileStorageHelper
{
    Task<string> SaveImageAsync(IFormFile file);
    Task DeleteImageAsync(string fileName);
}