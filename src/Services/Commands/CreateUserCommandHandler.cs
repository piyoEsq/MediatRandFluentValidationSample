using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace src.Services.Commands
{
    public class CreateUserCommandHandler : INotificationHandler<CreateUserCommand>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CreateUserCommand notification, CancellationToken cancellationToken)
        {
            // Userを作成するような処理...
            
            return Task.CompletedTask;
        }
    }
}