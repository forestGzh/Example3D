using System;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;
using Example3D.Infrastructure.Core;
using Example3D.Accounts.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example3D.Accounts.Infrastructure.Context
{
    public class DomainDbContext : EFDbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DomainDbContext(IMediator mediator, DbContextOptions<DomainDbContext> options) : base(mediator, options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
        }
    }
}
