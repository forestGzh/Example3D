using System;
using System.Threading;
using System.Threading.Tasks;
using Example3D.Infrastructure.Core.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example3D.Infrastructure.Core.Behaviors
{
    /// <summary>
    /// 事务管理过程
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class TransactionBehavior<TDbContext, TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TDbContext : EFDbContext
    {
        private readonly ILogger<TransactionBehavior<TDbContext, TRequest, TResponse>> _logger;
        private readonly TDbContext _dbContext;

        public TransactionBehavior(TDbContext dbContext, ILogger<TransactionBehavior<TDbContext, TRequest, TResponse>> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);
            var typeName = request.GetGenericTypeName();

            try
            {
                if (_dbContext.HasActiveTransaction)
                {
                    return await next();
                }

                // 定义了一个数据库操作执行的策略，可以嵌入一些自定义逻辑
                var strategy = _dbContext.Database.CreateExecutionStrategy();// 默认策略

                // 策略的执行过程
                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;
                    using (var transaction = await _dbContext.BeginTransactionAsync())
                    using (_logger.BeginScope("TransactionContext:{TransactionId}", transaction.TransactionId))
                    {
                        _logger.LogInformation("----- 开始事务 {TransactionId} ({@Command})", transaction.TransactionId, typeName, request);

                        response = await next();

                        _logger.LogInformation("----- 提交事务 {TransactionId} {CommandName}", transaction.TransactionId, typeName);


                        await _dbContext.CommitTransactionAsync(transaction);

                        transactionId = transaction.TransactionId;
                    }
                });

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "处理事务出错 {CommandName} ({@Command})", typeName, request);

                throw;
            }
        }
    }
}
