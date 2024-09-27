using Dance.Store.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Store.Application.Validators;

public class RegistrationStatusRequestValidator : AbstractValidator<RegistrationStatusRequestDto>
{
    public RegistrationStatusRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");
    }
}