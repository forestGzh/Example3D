using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;
using Example3D.Accounts.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Example3D.Accounts.Application.Queries
{
    public class AccountQueries : IAccountQueries
    {
        private readonly string _connectionString = string.Empty;
        private readonly IAccountRepository _accountRepository;

        public AccountQueries(IOptions<DomainDbSettings> options, IAccountRepository accountRepository)
        {
            _connectionString = options.Value.ConectionString;
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
        {
            var result = await _accountRepository.GetAllAsync();


            return result.Select(x => new AccountDto
            {
                Id = x.Id,
                Name = x.Name,
                Street = x.Address.Street,
                City = x.Address.City,
                Country = x.Address.Country
            });
        }

    }

    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
