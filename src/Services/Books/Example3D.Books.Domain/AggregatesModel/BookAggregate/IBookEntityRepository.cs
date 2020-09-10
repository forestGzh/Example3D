using System;
using Example3D.Infrastructure.Core;

namespace Example3D.Books.Domain.AggregatesModel.BookAggregate
{
    public interface IBookEntityRepository : IRepository<BookEntity>
    {
    }
}
