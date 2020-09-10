using System;
using MediatR;

namespace Example3D.Books.Application.Commands
{
    public class CreateBookEntityCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public string Quantity { get; private set; }

        public CreateBookEntityCommand(string name, string quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }

    public class CreateBookEntityCommandRequestDto
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
