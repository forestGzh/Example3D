using System;
using Example3D.Infrastructure.Core;

namespace Example3D.Accounts.Domain.AggregatesModel.AccountAggregate
{
    public interface IAccountRepository : IRepository<Account>
    {
    }
}
