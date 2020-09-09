using System;
using Example3D.Infrastructure.Core;

namespace Example3D.Book.Domain.AggregatesModel.BookAggregate
{
    public interface IBookEntityRepository : IRepository<BookEntity>
    {
    }
}
