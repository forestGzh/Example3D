using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Example3D.Account.Domain.AggregatesModel.AccountAggregate;
using MediatR;

namespace Example3D.Account.Application.Queries
{
    public class AccountQueryHandler : IRequestHandler<AccountQuery, List<AccountDto>>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<AccountDto>> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountRepository.GetAllAsync();


            return result.Select(x => new AccountDto
            {
                Id = x.Id,
                Name = x.Name,
                Street = x.Address.Street,
                City = x.Address.City,
                Country = x.Address.Country
            }).ToList();
        }
    }
}
