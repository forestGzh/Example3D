using System;
using Example3D.Books.Domain.AggregatesModel.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example3D.Books.Infrastructure.EntityConfigurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");

            builder.HasKey(p => p.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(p => p.Name).HasMaxLength(10);

            builder.Property(p => p.Quantity).HasMaxLength(10);
        }
    }
}
