using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services.File;

public interface IFileService
{
    Task<string> UploadFile(IFormFile file, string destinationFolder);
}