using System;
using System.Threading;
using System.Threading.Tasks;
using FileUploader.Domain.Repositories;

namespace FileUploader.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ITransactionRepository Transactions { get; }

        void SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}