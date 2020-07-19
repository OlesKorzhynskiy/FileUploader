using System.Linq;
using FileUploader.Application.Helpers;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace FileUploader.API.Infrastructure.Validation
{
    public class TransactionFileValidator : AbstractValidator<IFormFile>
    {
        public TransactionFileValidator()
        {
            RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(Constants.MaxFileSize)
                .WithMessage("File size is larger than allowed");

            RuleFor(file => file.FileName).NotNull().Must(fileName => Constants.AllowedFileExtensions.Any(fileName.EndsWith))
                .WithMessage("Unknown format");
        }
    }
}