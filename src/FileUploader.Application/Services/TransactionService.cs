using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.Application.Factories;
using FileUploader.Application.Interfaces;
using FileUploader.Application.Models;
using FileUploader.Domain;
using FileUploader.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<TransactionResponseModel>> Get(TransactionFilterModel filterModel)
        {
            var transactions = await GetFiltered(filterModel);
            var result = transactions.Adapt<List<TransactionResponseModel>>();
            return result;
        }

        private async Task<List<Transaction>> GetFiltered(TransactionFilterModel filterModel)
        {
            var transactions = _unitOfWork.Transactions.GetAll();

            if (!string.IsNullOrEmpty(filterModel.Status))
            {
                transactions = transactions.Where(t => t.Status.ToLower() == filterModel.Status.ToLower());
            }

            if (filterModel.StartDateTime.HasValue)
            {
                transactions = transactions.Where(t => t.Date > filterModel.StartDateTime.Value);
            }

            if (filterModel.EndDateTime.HasValue)
            {
                transactions = transactions.Where(t => t.Date < filterModel.EndDateTime.Value);
            }

            if (!string.IsNullOrEmpty(filterModel.Currency))
            {
                transactions = transactions.Where(t => t.CurrencyCode.ToLower() == filterModel.Currency.ToLower());
            }

            var result = await transactions.ToListAsync();
            return result;
        }
    }
}