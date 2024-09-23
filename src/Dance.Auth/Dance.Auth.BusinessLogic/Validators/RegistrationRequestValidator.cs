using FluentValidation;

namespace Dance.Auth.Business.Validators;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequestDto>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}