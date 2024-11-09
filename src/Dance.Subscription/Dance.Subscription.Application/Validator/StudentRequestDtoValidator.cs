using Dance.Subscription.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Subscription.Application.Validator;

public class StudentRequestDtoValidator : AbstractValidator<StudentRequestDto>
{
    public StudentRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");

        RuleFor(x => x.SubscriptionIds)
            .NotNull().WithMessage("SubscriptionIds cannot be null.")
            .Must(ids => ids.Count > 0).WithMessage("At least one SubscriptionId must be provided.")
            .ForEach(id => id.NotEmpty().WithMessage("SubscriptionId cannot be empty."));
    }
}