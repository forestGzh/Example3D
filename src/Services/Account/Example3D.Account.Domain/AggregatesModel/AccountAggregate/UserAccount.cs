using System;
using Example3D.Domain.Core;

namespace Example3D.Account.Domain.AggregatesModel.AccountAggregate
{
    public class UserAccount : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }

        protected UserAccount()
        {

        }

        public UserAccount(Guid id, string name, Address address)
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
