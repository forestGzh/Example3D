using System;
using MediatR;

namespace Example3D.Books.Application.Commands
{
    public class CreateBookCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public string Quantity { get; private set; }

        public CreateBookCommand(string name, string quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }

    public class CreateBookCommandRequestDto
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
