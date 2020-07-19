using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FileUploader.Domain.Entities;
using FileUploader.Domain.Repositories;

namespace FileUploader.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        protected readonly ApplicationDbContext Context;

        public TransactionRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task AddRangeAsync(IEnumerable<Transaction> entities)
        {
            if (entities is null) throw new ArgumentNullException(nameof(entities));

            await Context.Set<Transaction>().AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        private bool _disposed = false;
        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}