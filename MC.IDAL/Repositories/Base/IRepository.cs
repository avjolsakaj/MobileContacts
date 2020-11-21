using MC.ENTITY.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MC.IDAL.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity, int userId);

        Task<T> UpdateAsync(T entity, int userId);

        Task<T> GetAsync(long id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T> DeleteAsync(long id, int userId);

        Task<int> CountAsync();

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}
