using System;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;
using Example3D.Accounts.Infrastructure.Context;
using Example3D.Infrastructure.Core;

namespace Example3D.Accounts.Infrastructure.Repositories
{
    public class AccountRepository : Repository<UserAccount, Guid, DomainDbContext>, IAccountRepository
    {
        public AccountRepository(DomainDbContext context) : base(context)
        {
        }
    }
}
