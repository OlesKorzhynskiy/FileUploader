using System;
using System.Collections.Generic;

namespace FileUploader.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> Errors { get; set; }

        public BadRequestException(string errorMessage, List<string> errors = null) : base(errorMessage)
        {
            Errors = errors;
        }
    }
}