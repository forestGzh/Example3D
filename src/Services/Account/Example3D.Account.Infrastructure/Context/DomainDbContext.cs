using System;
using Example3D.Account.Domain.AggregatesModel.AccountAggregate;
using Example3D.Infrastructure.Core;
using Example3D.Account.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example3D.Account.Infrastructure.Context
{
    public class DomainDbContext : EFDbContext
    {
        public DbSet<UserAccount> Accounts { get; set; }

        public DomainDbContext(IMediator mediator, DbContextOptions<DomainDbContext> options) : base(mediator, options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
        }
    }
}
