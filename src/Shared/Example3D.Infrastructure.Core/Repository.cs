using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Example3D.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Example3D.Infrastructure.Core
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot where TDbContext : EFDbContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public IUnitOfWork UnitOfWork => DbContext;

        public Repository(TDbContext context)
        {
            DbContext = context;
        }

        public TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await DbContext.AddAsync(entity)).Entity;
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            DbContext.AddRange(entities);
        }

        public Task AddRangeAsync(ICollection<TEntity> entities)
        {
            return DbContext.AddRangeAsync(entities);
        }

        public int Count(Expression<Func<TEntity, bool>> where = null)
        {
            return DbContext.Set<TEntity>().Where(where).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return await DbContext.Set<TEntity>().Where(where).CountAsync();
        }

        public bool Exist(Expression<Func<TEntity, bool>> where = null)
        {
            return (where == null ? DbContext.Set<TEntity>().Any() : DbContext.Set<TEntity>().Any(where));
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return await (where == null ? DbContext.Set<TEntity>().AnyAsync() : DbContext.Set<TEntity>().AnyAsync(where));
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            return DbContext.Set<TEntity>().AsNoTracking();
        }

        public Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return Task.FromResult(DbContext.Set<TEntity>().AsNoTracking());
        }

        public bool Remove(Entity entity)
        {
            DbContext.Remove(entity);
            return true;
        }

        public async Task<bool> RemoveAsync(Entity entity)
        {
            return await Task.FromResult(Remove(entity));
        }

        public TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.FromResult(DbContext.Update(entity).Entity);
        }

        public bool RemoveRange(ICollection<TEntity> entities)
        {
            DbContext.RemoveRange(entities);
            return true;
        }

        public async Task<bool> RemoveRangeAsync(ICollection<TEntity> entities)
        {
            return await Task.FromResult(RemoveRange(entities));
        }
    }

    public abstract class Repository<TEntity, TKey, TDbContext> : Repository<TEntity, TDbContext>, IRepository<TEntity, TKey> where TEntity : Entity<TKey>, IAggregateRoot where TDbContext : EFDbContext
    {
        public Repository(TDbContext context) : base(context)
        {
        }

        public bool Delete(TKey id)
        {
            var entity = DbContext.Find<TEntity>(id);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await DbContext.FindAsync<TEntity>(id);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public TEntity GetSingle(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public async Task<TEntity> GetSingleAsync(TKey id)
        {
            var entity = await DbContext.FindAsync<TEntity>(id);
            return entity;
        }
    }
}
