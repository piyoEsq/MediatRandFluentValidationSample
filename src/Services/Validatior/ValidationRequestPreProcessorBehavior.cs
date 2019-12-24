using System.Threading;
using System.Threading.Tasks;
using CQRSSample.Services.Queries;
using MediatR.Pipeline;

namespace CQRSSample.Services.Validatior
{
    public class ValidationRequestPreProcessorBehavior : IRequestPreProcessor<GetUserByIdQuery>
    {
        public Task Process(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}