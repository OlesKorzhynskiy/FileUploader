using System.Collections.Generic;
using System.Threading.Tasks;
using FileUploader.Application.Models;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Interfaces
{
    public interface ITransactionService
    {
        Task AddAsync(IFormFile file);

        Task<List<TransactionResponseModel>> Get(TransactionFilterModel filterModel);
    }
}