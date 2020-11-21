using MC.DAL.Context;
using MC.ENTITY.Models.Base;
using MC.IDAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MC.DAL.Repositories.Base
{
    public abstract class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MCContext _context;

        protected GenericRepository(MCContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> AddAsync(T? entity)
        {
            if (entity is null)
            {
                return null;
            }

            entity.IsActive = true;
            entity.Deleted = false;

            var result = await _context.AddAsync(entity).ConfigureAwait(false);

            return result.Entity;
        }

        public virtual async Task<bool> AddRangeAsync(List<T> entity)
        {
            foreach (var item in entity)
            {
                item.IsActive = true;
                item.Deleted = false;
            }

            await _context.AddRangeAsync(entity).ConfigureAwait(false);

            return true;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(x => !x.Deleted).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => !x.Deleted && x.Id == id).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(x => !x.Deleted).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var existing = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id && !x.Deleted).ConfigureAwait(false);

            if (existing is null)
            {
                throw new KeyNotFoundException($"Can't find object {typeof(T)}, with id {entity.Id}");
            }

            _context.Entry(existing).CurrentValues.SetValues(entity);

            return existing;
        }

        public virtual async Task<T> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id && !x.Deleted).ConfigureAwait(false);

            if (entity != null)
            {
                entity.IsActive = false;

                entity.Deleted = true;

                return entity;
            }
            else
            {
                return null;
            }
        }

        public virtual async Task<int> CountAsync()
        {
            return await _context.Set<T>().Where(x => !x.Deleted).CountAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
