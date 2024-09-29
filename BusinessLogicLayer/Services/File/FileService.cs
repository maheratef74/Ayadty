using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services.File;

public class FileService : IFileService
{
    public async Task<string> UploadFile(IFormFile file, string destinationFolder)
    {
            string uniqueFileName = string.Empty;

            if (file != null && file.Length > 0)
            {
                string uploadsFolder = Path.Combine(@"./wwwroot/", destinationFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create , FileAccess.Write, FileShare.None, 4096, useAsync: true))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return uniqueFileName;
    }
}