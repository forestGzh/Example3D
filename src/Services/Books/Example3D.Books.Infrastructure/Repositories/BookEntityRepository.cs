using System;
using Example3D.Books.Domain.AggregatesModel.BookAggregate;
using Example3D.Books.Infrastructure.Context;
using Example3D.Infrastructure.Core;

namespace Example3D.Books.Infrastructure.Repositories
{
    public class BookEntityRepository : Repository<BookEntity, Guid, DomainDbContext>, IBookEntityRepository
    {
        public BookEntityRepository(DomainDbContext context) : base(context)
        {
        }
    }
}
