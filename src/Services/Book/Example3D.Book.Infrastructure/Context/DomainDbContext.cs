using System;
using Example3D.Book.Domain.AggregatesModel.BookAggregate;
using Example3D.Infrastructure.Core;
using Example3D.Book.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example3D.Book.Infrastructure.Context
{
    public class DomainDbContext : EFDbContext
    {
        public DbSet<BookEntity> BookEntitys { get; set; }

        public DomainDbContext(IMediator mediator, DbContextOptions<DomainDbContext> options) : base(mediator, options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityEntityTypeConfiguration());
        }
    }
}
