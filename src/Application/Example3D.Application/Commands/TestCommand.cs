using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Example3D.Application.Commands
{
    public class TestCommand : IRequest
    {
        public TestCommand()
        {
        }
    }

    public class TestCommandHandler : IRequestHandler<TestCommand>
    {
        private readonly ILogger<TestCommand> _logger;

        public TestCommandHandler(ILogger<TestCommand> logger)
        {
            _logger = logger;
        }

        public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TestCommand");

            await Task.CompletedTask;

            return Unit.Value;
        }
    }
}
