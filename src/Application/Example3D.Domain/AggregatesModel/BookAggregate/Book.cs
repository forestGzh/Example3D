using System;
using Example3D.Domain.Core;

namespace Example3D.Domain.AggregatesModel.BookAggregate
{
    public class Book : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Quantity { get; private set; }

        protected Book()
        {

        }

        public Book(Guid id, string name, string quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

    }
}
