using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example3D.Domain.AggregatesModel.BookAggregate;

namespace Example3D.Application.Queries
{
    public class BookQueries : IBookQueries
    {
        private readonly IBookRepository _bookRepository;
        public BookQueries(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var result = await _bookRepository.GetAllAsync();


            return result.Select(x => new BookDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity
            });
        }

    }

    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
