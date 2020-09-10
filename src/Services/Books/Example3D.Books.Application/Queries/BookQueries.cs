using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Example3D.Books.Domain.AggregatesModel.BookAggregate;
using Example3D.Books.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Example3D.Books.Application.Queries
{
    public class BookQueries : IBookQueries
    {
        private readonly string _connectionString = string.Empty;
        private readonly IBookRepository _bookRepository;
        public BookQueries(IOptions<DomainDbSettings> options, IBookRepository bookRepository)
        {
            _connectionString = options.Value.ConectionString;
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
