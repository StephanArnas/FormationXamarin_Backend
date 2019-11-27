using CryptoBankBackend.Core.Interfaces.Repositories;
using CryptoBankBackend.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CryptoBankBackend.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CryptoBankBackend.Infrastructure.Repositories
{
    public class ReposityBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        protected readonly ApplicationDbContext Context = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public ReposityBase(ApplicationDbContext context)
        {
            Context = context;
        }

        #endregion

        #region ----- PUBLIC METHODS --------------------------------------------------

        public async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            // In case AsNoTracking is used
            entity.ModifiedDate = DateTimeOffset.UtcNow;
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task RemoveAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await Context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().CountAsync(predicate);
        }

        #endregion
    }
}
