using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;
using CQRSSample.Services.Queries;
using System;
using CQRSSample.Models;

namespace CQRSSample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;

        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            this._mediator = mediator;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Query
            User user = null;
            user = await _mediator.Send(new GetUserByIdQuery() { Id = Guid.NewGuid() });
            
            // 以下のQueryはValidatorにより例外が吐かれる
            // user = await _mediator.Send(new GetUserByIdQuery() { Id = Guid.Empty });

            _logger.LogInformation($"Id : {user.Id.ToString()}");
            _logger.LogInformation($"Name : {user.Name?.ToString()}");
        }
    }
}
