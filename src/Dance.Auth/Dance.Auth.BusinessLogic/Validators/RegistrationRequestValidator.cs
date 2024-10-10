using Dance.Auth.BusinessLogic.Dtos;
using Dance.Auth.BusinessLogic.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Auth.BusinessLogic.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequestDto>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Passwords must have at least one non-alphanumeric character.")
            .Matches("[0-9]").WithMessage("Passwords must have at least one digit ('0'-'9').")
            .Matches("[A-Z]").WithMessage("Passwords must have at least one uppercase ('A'-'Z')."); ;
    }
}