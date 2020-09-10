using System;
using Example3D.Account.Domain.AggregatesModel.AccountAggregate;
using Example3D.Account.Infrastructure.Context;
using Example3D.Infrastructure.Core;

namespace Example3D.Account.Infrastructure.Repositories
{
    public class AccountRepository : Repository<UserAccount, Guid, DomainDbContext>, IAccountRepository
    {
        public AccountRepository(DomainDbContext context) : base(context)
        {
        }
    }
}
