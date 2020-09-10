using System;
using System.Threading;
using System.Threading.Tasks;
using Example3D.Books.Domain.AggregatesModel.BookAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using Volo.Abp.Guids;

namespace Example3D.Books.Application.Commands
{
    public class CreateBookEntityCommandHandler : IRequestHandler<CreateBookEntityCommand, bool>
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ILogger<CreateBookEntityCommandHandler> _logger;
        private readonly IBookEntityRepository _bookEntityRepository;

        public CreateBookEntityCommandHandler(IGuidGenerator guidGenerator, ILogger<CreateBookEntityCommandHandler> logger, IBookEntityRepository bookEntityRepository)
        {
            _guidGenerator = guidGenerator ?? throw new ArgumentNullException(nameof(guidGenerator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookEntityRepository = bookEntityRepository ?? throw new ArgumentNullException(nameof(bookEntityRepository));
        }

        public async Task<bool> Handle(CreateBookEntityCommand request, CancellationToken cancellationToken)
        {
            Book bookEntity = new Book(_guidGenerator.Create(), request.Name, request.Quantity);

            _logger.LogInformation("----- Creating BookEntity - BookEntity: {@BookEntity}", bookEntity);

            _bookEntityRepository.Add(bookEntity);

            return await _bookEntityRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

        }
    }
}
