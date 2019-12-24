using System.Threading;
using System.Threading.Tasks;
using CQRSSample.Models;
using CQRSSample.Services.Queries;
using MediatR.Pipeline;

namespace CQRSSample.Services.Validatior
{
    public class ValidationRequestPostProcessorBehavior : IRequestPostProcessor<GetUserByIdQuery, User>
    {
        public Task Process(GetUserByIdQuery request, User response, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}