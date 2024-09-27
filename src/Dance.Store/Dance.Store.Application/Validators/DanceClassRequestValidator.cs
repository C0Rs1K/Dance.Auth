using Dance.Store.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Store.Application.Validators;

public class DanceClassRequestValidator : AbstractValidator<DanceClassRequestDto>
{
    public DanceClassRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.TrainerId)
            .NotEmpty()
            .WithMessage("TrainerId is required.");

        RuleFor(x => x.ClassDuration)
            .GreaterThan(0)
            .WithMessage("ClassDuration must be greater than zero.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(x => x.NumberOfPlaces)
            .GreaterThan(0)
            .WithMessage("NumberOfPlaces must be greater than zero.");

        RuleFor(x => x.Date)
            .GreaterThan(DateTime.Now)
            .WithMessage("Date must be in the future.");
    }
}