using System;
using System.Collections.Generic;
using Example3D.Domain.Core;

namespace Example3D.Account.Domain.AggregatesModel.AccountAggregate
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public Address() { }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return Country;
        }
    }
}
