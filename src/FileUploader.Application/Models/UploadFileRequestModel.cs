using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Models
{
    public class UploadFileRequestModel
    {
        public IFormFile File { get; set; }
    }
}