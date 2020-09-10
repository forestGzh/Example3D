using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;

namespace Example3D.Accounts.Application.Queries
{
    public interface IAccountQueries
    {
        Task<IEnumerable<AccountDto>> GetAccountsAsync();
    }
}
