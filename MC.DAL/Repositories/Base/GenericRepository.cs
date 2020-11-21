﻿using MC.DAL.Context;
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

        public virtual async Task<T> AddAsync(T entity, int userId)
        {
            entity.IsActive = true;
            entity.Deleted = false;

            var result = await _context.AddAsync(entity).ConfigureAwait(false);

            return result.Entity;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(x => !x.Deleted).Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => !x.Deleted && x.Id == id).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(x => !x.Deleted).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> UpdateAsync(T entity, int userId)
        {
            var existing = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id && !x.Deleted).ConfigureAwait(false);

            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
            }
            else
            {
                throw new KeyNotFoundException($"Can't find object {typeof(T)}, with id {entity.Id}");
            }

            return existing;
        }

        public virtual async Task<T> DeleteAsync(long id, int userId)
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
                throw new KeyNotFoundException($"Can't find object {typeof(T)}, with id {id}");
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
