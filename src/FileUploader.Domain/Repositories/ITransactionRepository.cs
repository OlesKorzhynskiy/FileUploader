using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FileUploader.Domain.Entities;

namespace FileUploader.Domain.Repositories
{
    public interface ITransactionRepository : IDisposable
    {
        Task AddRangeAsync(IEnumerable<Transaction> entity);
    }
}