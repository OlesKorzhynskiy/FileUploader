using FileUploader.Application.Models;
using FluentValidation;

namespace FileUploader.API.Infrastructure.Validation
{
    public class UploadFileRequestModelValidator : AbstractValidator<UploadFileRequestModel>
    {
        public UploadFileRequestModelValidator()
        {
            RuleFor(t => t.File).NotNull().SetValidator(new TransactionFileValidator());
        }
    }
}