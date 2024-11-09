using Dance.Store.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Store.Application.Validators;

public class StudentRequestValidator : AbstractValidator<StudentRequestDto>
{
    public StudentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone is required.")
            .Length(7, 16)
            .WithMessage("Phone must be between 7 and 16 characters.");

        RuleFor(x => x.Instagram)
            .MaximumLength(64)
            .WithMessage("Instagram must not exceed 64 characters.");
    }
}