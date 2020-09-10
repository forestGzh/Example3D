using System;
using Example3D.Accounts.Infrastructure.Context;
using Example3D.Infrastructure.Core.Behaviors;
using Microsoft.Extensions.Logging;

namespace Example3D.Accounts.Infrastructure.Behaviors
{
    public class DomainDbContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<DomainDbContext, TRequest, TResponse>
    {
        public DomainDbContextTransactionBehavior(DomainDbContext dbContext, ILogger<DomainDbContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {
        }
    }
}
