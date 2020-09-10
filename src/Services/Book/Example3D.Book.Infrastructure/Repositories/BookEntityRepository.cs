using System;
using Example3D.Book.Domain.AggregatesModel.BookAggregate;
using Example3D.Book.Infrastructure.Context;
using Example3D.Infrastructure.Core;

namespace Example3D.Book.Infrastructure.Repositories
{
    public class BookEntityRepository : Repository<BookEntity, Guid, DomainDbContext>, IBookEntityRepository
    {
        public BookEntityRepository(DomainDbContext context) : base(context)
        {
        }
    }
}
