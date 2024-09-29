using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services.File;

public interface IFileService
{
    string UploadFile(IFormFile file, string destinationFolder);
}