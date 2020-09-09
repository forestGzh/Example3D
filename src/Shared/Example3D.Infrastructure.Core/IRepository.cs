using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Example3D.Domain.Core;

namespace Example3D.Infrastructure.Core
{
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        ///添加多个实体
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(ICollection<TEntity> entities);

        /// <summary>
        /// 添加多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(ICollection<TEntity> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Remove(Entity entity);

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(Entity entity);

        /// <summary>
        /// 移除多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool RemoveRange(ICollection<TEntity> entities);

        /// <summary>
        /// 移除多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> RemoveRangeAsync(ICollection<TEntity> entities);

        /// <summary>
        /// 根据条件返回实体个数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// 根据条件返回实体个数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// 根据条件判断是否存在指定的实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool Exist(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// 根据条件判断是否存在指定的实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// 根据条件获取所有的实体，并且取消跟踪
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null);

        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null);
    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : Entity<TKey>, IAggregateRoot
    {
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(TKey id);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TKey id);

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetSingle(TKey id);

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetSingleAsync(TKey id);
    }
}
