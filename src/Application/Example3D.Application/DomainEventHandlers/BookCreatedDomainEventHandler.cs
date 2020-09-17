using System;
using System.Threading;
using System.Threading.Tasks;
using Example3D.Application.Commands;
using Example3D.Domain.AggregatesModel.BookAggregate.Events;
using Example3D.Domain.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Example3D.Application.DomainEventHandlers
{
    public class BookCreatedDomainEventHandler : IDomainEventHandler<BookCreatedDomainEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookCreatedDomainEventHandler> _logger;
        public BookCreatedDomainEventHandler(IMediator mediator, ILogger<BookCreatedDomainEventHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(BookCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("BookCreatedDomainEvent1");

            TestCommand command = new TestCommand();
            await _mediator.Send(command);

            await Task.CompletedTask;
        }
    }

    public class BookCreatedDomainEvent2Handler : IDomainEventHandler<BookCreatedDomainEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookCreatedDomainEvent2Handler> _logger;
        public BookCreatedDomainEvent2Handler(IMediator mediator, ILogger<BookCreatedDomainEvent2Handler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(BookCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BookCreatedDomainEvent2");

            TestCommand command = new TestCommand();
            await _mediator.Send(command);

            await Task.CompletedTask;
        }
    }
}
