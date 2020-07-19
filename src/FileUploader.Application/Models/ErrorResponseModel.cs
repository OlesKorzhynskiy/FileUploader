using System.Collections.Generic;

namespace FileUploader.Application.Models
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}