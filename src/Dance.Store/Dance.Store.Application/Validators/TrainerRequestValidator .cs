using Dance.Store.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Store.Application.Validators;

public class TrainerRequestValidator : AbstractValidator<TrainerRequestDto>
{
    public TrainerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone is required.")
            .Length(7, 16)
            .WithMessage("Phone must be between 7 and 16 characters.");
    }
}