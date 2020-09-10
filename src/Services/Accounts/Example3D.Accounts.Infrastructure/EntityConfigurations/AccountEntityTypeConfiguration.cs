using System;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example3D.Accounts.Infrastructure.EntityConfigurations
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");

            builder.HasKey(p => p.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(p => p.Name).HasMaxLength(10);

            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
                a.Property(p => p.Street).HasMaxLength(10);
                a.Property(p => p.City).HasMaxLength(10);
                a.Property(p => p.Country).HasMaxLength(10);
            });
        }
    }
}
