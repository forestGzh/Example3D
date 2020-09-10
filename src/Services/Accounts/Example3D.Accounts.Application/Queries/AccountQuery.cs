using System;
using System.Collections.Generic;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;
using MediatR;

namespace Example3D.Accounts.Application.Queries
{
    public class AccountQuery : IRequest<List<AccountDto>>
    {
        public AccountQuery()
        {
        }
    }
}
