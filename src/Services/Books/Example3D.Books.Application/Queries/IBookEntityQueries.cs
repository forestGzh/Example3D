using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example3D.Books.Application.Queries
{
    public interface IBookEntityQueries
    {
        Task<IEnumerable<BookEntityDto>> GetBooksAsync();
    }
}
