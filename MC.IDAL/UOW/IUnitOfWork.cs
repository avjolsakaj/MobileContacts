using MC.IDAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace MC.IDAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<IDbContextTransaction?> CommitTransactionAsync(IDbContextTransaction? transaction);

        Task<IDbContextTransaction?> RollbackTransactionAsync(IDbContextTransaction? transaction);

        // TODO: Add other repositories

        ITestRepository TestRepository { get; }
    }
}
