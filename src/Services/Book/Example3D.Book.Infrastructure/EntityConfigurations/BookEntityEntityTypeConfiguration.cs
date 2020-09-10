using System;
using Example3D.Book.Domain.AggregatesModel.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example3D.Book.Infrastructure.EntityConfigurations
{
    public class BookEntityEntityTypeConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.ToTable("book");

            builder.HasKey(p => p.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(p => p.Name).HasMaxLength(10);

            builder.Property(p => p.Quantity).HasMaxLength(10);
        }
    }
}
