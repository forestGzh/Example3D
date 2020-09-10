using System;
using Example3D.Books.Domain.AggregatesModel.BookAggregate;
using Example3D.Infrastructure.Core;
using Example3D.Books.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example3D.Books.Infrastructure.Context
{
    public class DomainDbContext : EFDbContext
    {
        public DbSet<Book> Books { get; set; }

        public DomainDbContext(IMediator mediator, DbContextOptions<DomainDbContext> options) : base(mediator, options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
        }
    }
}
