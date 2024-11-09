using Dance.Store.Application.Dtos.RequestDto;
using FluentValidation;

namespace Dance.Store.Application.Validators;

public class StudentRegistrationRequestValidator : AbstractValidator<StudentRegistrationRequestDto>
{
    public StudentRegistrationRequestValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty()
            .WithMessage("StudentId is required.");

        RuleFor(x => x.ClassId)
            .NotEmpty()
            .WithMessage("ClassId is required.");

        RuleFor(x => x.StatusId)
            .NotEmpty()
            .WithMessage("StatusId is required.");
    }
}