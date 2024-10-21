using Dance.Auth.BusinessLogic.Dtos;
using Dance.Auth.BusinessLogic.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Auth.BusinessLogic.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}