using System;
using System.Threading;
using System.Threading.Tasks;
using FileUploader.Domain;
using FileUploader.Domain.Repositories;
using FileUploader.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FileUploader.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private ITransactionRepository _transactions;
        public ITransactionRepository Transactions => _transactions ??= new TransactionRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}