using MC.DAL.Context;
using MC.DAL.Repositories;
using MC.IDAL.Repositories;
using MC.IDAL.UOW;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace MC.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MCContext _context;

        public UnitOfWork(MCContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }

        public async Task<IDbContextTransaction?> CommitTransactionAsync(IDbContextTransaction? transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("Transaction can't be null");
            }

            try
            {
                await transaction.CommitAsync().ConfigureAwait(false);
                await transaction.DisposeAsync().ConfigureAwait(false);
            }
            catch
            {
                _ = await RollbackTransactionAsync(transaction).ConfigureAwait(false);
            }

            return null;
        }

        public async Task<IDbContextTransaction?> RollbackTransactionAsync(IDbContextTransaction? transaction)
        {
            if (transaction is null)
            {
                return null;
            }

            await transaction.RollbackAsync().ConfigureAwait(false);
            await transaction.DisposeAsync().ConfigureAwait(false);

            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        private ITestRepository? _testRepository;
        public ITestRepository TestRepository => _testRepository ??= new TestRepository(_context);
    }
}
