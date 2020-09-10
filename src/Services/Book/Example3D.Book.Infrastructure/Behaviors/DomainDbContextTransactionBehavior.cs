using System;
using Example3D.Book.Infrastructure.Context;
using Example3D.Infrastructure.Core.Behaviors;
using Microsoft.Extensions.Logging;

namespace Example3D.Book.Infrastructure.Behaviors
{
    public class DomainDbContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<DomainDbContext, TRequest, TResponse>
    {
        public DomainDbContextTransactionBehavior(DomainDbContext dbContext, ILogger<DomainDbContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {
        }
    }
}
