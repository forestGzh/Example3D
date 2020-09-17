using System;
using System.Threading;
using System.Threading.Tasks;
using Example3D.Domain.AggregatesModel.BookAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using Volo.Abp.Guids;

namespace Example3D.Application.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ILogger<CreateBookCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IGuidGenerator guidGenerator, ILogger<CreateBookCommandHandler> logger, IBookRepository bookRepository)
        {
            _guidGenerator = guidGenerator ?? throw new ArgumentNullException(nameof(guidGenerator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<bool> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = new Book(_guidGenerator.Create(), request.Name, request.Quantity);

            _logger.LogInformation("----- Creating Book- Book: {@Book}", book);

            _bookRepository.Add(book);

            return await _bookRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

        }
    }
}
