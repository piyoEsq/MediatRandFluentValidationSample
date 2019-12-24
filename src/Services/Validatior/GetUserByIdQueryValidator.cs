using System;
using CQRSSample.Services.Queries;
using FluentValidation;

namespace CQRSSample.Services.Validatior
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(_ => Guid.Empty);
        }
    }
}