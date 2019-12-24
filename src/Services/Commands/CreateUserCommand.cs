using System;
using MediatR;

namespace src.Services.Commands
{
    public class CreateUserCommand : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}