using CloudinaryDotNet.Actions;

namespace WebApplication1.Interfaces;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotosAsync(string publicId);
    
}