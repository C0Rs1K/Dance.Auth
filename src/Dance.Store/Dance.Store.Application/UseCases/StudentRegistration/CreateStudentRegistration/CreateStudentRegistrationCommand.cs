using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.CreateStudentRegistration;

public record CreateStudentRegistrationCommand(StudentRegistrationRequestDto studentRegistrationRequestDto) : IRequest<Guid>;