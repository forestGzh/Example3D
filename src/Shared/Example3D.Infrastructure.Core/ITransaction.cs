using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Example3D.Infrastructure.Core
{
    public interface ITransaction
    {
        /// <summary>
        /// 获取当前事务
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction GetCurrentTransaction();

        bool HasActiveTransaction { get; }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task CommitTransactionAsync(IDbContextTransaction transaction);

        /// <summary>
        /// 事务回滚
        /// </summary>
        void RollBackTransaction();
    }
}
