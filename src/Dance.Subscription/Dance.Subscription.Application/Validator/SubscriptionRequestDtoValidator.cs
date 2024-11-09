using Dance.Subscription.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Subscription.Application.Validator;

public class SubscriptionRequestDtoValidator : AbstractValidator<SubscriptionRequestDto>
{
    public SubscriptionRequestDtoValidator()
    {
        RuleFor(x => x.NumberOfClasses)
            .GreaterThan(0).WithMessage("NumberOfClasses must be greater than zero.");

        RuleFor(x => x.ValidityPeriodInDays)
            .GreaterThan(0).WithMessage("ValidityPeriodInDays must be greater than zero.");
    }
}