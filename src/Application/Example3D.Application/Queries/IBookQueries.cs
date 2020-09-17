using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example3D.Application.Queries
{
    public interface IBookQueries
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
    }
}
