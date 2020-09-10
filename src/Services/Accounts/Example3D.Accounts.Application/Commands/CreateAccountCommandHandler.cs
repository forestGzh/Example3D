using System;
using System.Threading;
using System.Threading.Tasks;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using Volo.Abp.Guids;

namespace Example3D.Accounts.Application.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, bool>
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ILogger<CreateAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IGuidGenerator guidGenerator, ILogger<CreateAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _guidGenerator = guidGenerator ?? throw new ArgumentNullException(nameof(guidGenerator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Address address = new Address(request.Street, request.City, request.Country);
            Account account = new Account(_guidGenerator.Create(), request.Name, address);

            _logger.LogInformation("----- Creating Account - Account: {@Account}", account);

            _accountRepository.Add(account);

            return await _accountRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

        }
    }
}
