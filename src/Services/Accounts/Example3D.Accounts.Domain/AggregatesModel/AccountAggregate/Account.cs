using System;
using Example3D.Domain.Core;

namespace Example3D.Accounts.Domain.AggregatesModel.AccountAggregate
{
    public class Account : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }

        protected Account()
        {

        }

        public Account(Guid id, string name, Address address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }
    }
}
