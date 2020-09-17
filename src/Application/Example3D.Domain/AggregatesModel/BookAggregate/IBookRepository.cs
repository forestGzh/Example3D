using System;
using Example3D.Infrastructure.Core;

namespace Example3D.Domain.AggregatesModel.BookAggregate
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
