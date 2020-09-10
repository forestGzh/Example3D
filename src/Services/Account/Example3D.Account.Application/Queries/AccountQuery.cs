using System;
using System.Collections.Generic;
using Example3D.Account.Domain.AggregatesModel.AccountAggregate;
using MediatR;

namespace Example3D.Account.Application.Queries
{
    public class AccountQuery : IRequest<List<AccountDto>>
    {
        public AccountQuery()
        {
        }
    }
}
