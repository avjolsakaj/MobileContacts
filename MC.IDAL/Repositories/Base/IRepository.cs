using MC.ENTITY.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MC.IDAL.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> AddAsync(T? entity);

        Task<bool> AddRangeAsync(List<T> entity);

        Task<T> UpdateAsync(T entity);

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T> DeleteAsync(int id);

        Task<int> CountAsync();

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}
