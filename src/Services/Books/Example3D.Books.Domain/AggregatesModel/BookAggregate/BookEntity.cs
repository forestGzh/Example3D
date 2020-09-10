using System;
using Example3D.Domain.Core;

namespace Example3D.Books.Domain.AggregatesModel.BookAggregate
{
    public class BookEntity : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Quantity { get; private set; }

        protected BookEntity()
        {

        }

        public BookEntity(Guid id, string name, string quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

    }
}
