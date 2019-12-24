using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using FluentValidation;
using System.Linq;

namespace CQRSSample.Services.Validatior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> logger;
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger,
                                  IEnumerable<IValidator<TRequest>> validator)
        {
            this.logger = logger;
            this.validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            logger.LogInformation("Handle Start.");

            var context = new ValidationContext(request);
            var failures = validator
                            .Select(s => s.Validate(context))
                            .SelectMany(s => s.Errors)
                            .Where(w => w != null)
                            .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            var response = next();

            logger.LogInformation("Handle End.");
            return response;
        }
    }
}