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
    public class BookEntityQueries : IBookEntityQueries
    {
        private readonly string _connectionString = string.Empty;
        private readonly IBookEntityRepository _bookEntityRepository;
        public BookEntityQueries(IOptions<DomainDbSettings> options, IBookEntityRepository bookEntityRepository)
        {
            _connectionString = options.Value.ConectionString;
            _bookEntityRepository = bookEntityRepository;
        }

        public async Task<IEnumerable<BookEntityDto>> GetBooksAsync()
        {
            var result = await _bookEntityRepository.GetAllAsync();


            return result.Select(x => new BookEntityDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity
            });
        }

    }

    public class BookEntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
