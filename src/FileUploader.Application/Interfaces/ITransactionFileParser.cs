using System.Collections;
using System.Collections.Generic;
using FileUploader.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Interfaces
{
    public interface ITransactionFileParser
    {
        IEnumerable<Transaction> Parse(IFormFile file);
    }
}