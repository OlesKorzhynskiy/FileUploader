using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FileUploader.Application.Factories;
using FileUploader.Application.Interfaces;
using FileUploader.Domain;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionFileParserFactory _fileParserFactory;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionFileParserFactory fileParserFactory, IUnitOfWork unitOfWork)
        {
            _fileParserFactory = fileParserFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(IFormFile file)
        {
            var fileParser = _fileParserFactory.CreateFileParser(file.FileName);
            var transactions = fileParser.Parse(file);

            await _unitOfWork.Transactions.AddRangeAsync(transactions);
        }
    }
}