using System;
using Example3D.Domain.AggregatesModel.BookAggregate;
using Example3D.Infrastructure.Contexts;
using Example3D.Infrastructure.Core;

namespace Example3D.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book, Guid, DomainDbContext>, IBookRepository
    {
        public BookRepository(DomainDbContext context) : base(context)
        {
        }
    }
}
