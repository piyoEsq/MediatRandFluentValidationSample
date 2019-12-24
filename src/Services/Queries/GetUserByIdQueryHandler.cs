using System.Threading;
using System.Threading.Tasks;
using CQRSSample.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSSample.Services.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly ILogger<GetUserByIdQueryHandler> logger;
        public GetUserByIdQueryHandler(ILogger<GetUserByIdQueryHandler> logger)
        {
            this.logger = logger;
        }

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Hadling...");

            // Userの検索処理...
            var user = new User { Id = request.Id, Name = "ほげほげ" };
            return Task.FromResult(user);
        }
    }
}