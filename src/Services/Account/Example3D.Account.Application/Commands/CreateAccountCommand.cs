using System;
using MediatR;

namespace Example3D.Account.Application.Commands
{
    public class CreateAccountCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public CreateAccountCommand(string name, string street, string city, string country)
        {
            Name = name;
            Street = street;
            City = city;
            Country = country;
        }
    }

    public class CreateAccountCommandRequestDto
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
