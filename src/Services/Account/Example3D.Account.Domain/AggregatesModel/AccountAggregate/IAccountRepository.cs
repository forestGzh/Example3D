using System;
using Example3D.Infrastructure.Core;

namespace Example3D.Account.Domain.AggregatesModel.AccountAggregate
{
    public interface IAccountRepository : IRepository<UserAccount>
    {
    }
}
