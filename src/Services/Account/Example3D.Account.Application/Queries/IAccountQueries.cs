using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Example3D.Account.Domain.AggregatesModel.AccountAggregate;

namespace Example3D.Account.Application.Queries
{
    public interface IAccountQueries
    {
        Task<IEnumerable<AccountDto>> GetAccountsAsync();
    }
}
