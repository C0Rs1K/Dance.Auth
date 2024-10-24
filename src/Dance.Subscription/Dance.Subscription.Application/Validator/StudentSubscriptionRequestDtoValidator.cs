using Dance.Subscription.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Subscription.Application.Validator;

public class StudentSubscriptionRequestDtoValidator : AbstractValidator<StudentSubscriptionRequestDto>
{
    public StudentSubscriptionRequestDtoValidator()
    {
        RuleFor(x => x.SubscriptionId)
            .NotEmpty().WithMessage("SubscriptionId is required.");

        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("StudentId is required.");
    }
}