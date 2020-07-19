using System.Collections.Generic;
using FileUploader.Application.Interfaces;
using FileUploader.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Services
{
    public class CsvTransactionFileParser : ITransactionFileParser
    {
        public IEnumerable<Transaction> Parse(IFormFile file)
        {
            throw new System.NotImplementedException();
        }
    }
}