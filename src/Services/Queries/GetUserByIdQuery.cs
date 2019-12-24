using System;
using CQRSSample.Models;
using MediatR;

namespace CQRSSample.Services.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}