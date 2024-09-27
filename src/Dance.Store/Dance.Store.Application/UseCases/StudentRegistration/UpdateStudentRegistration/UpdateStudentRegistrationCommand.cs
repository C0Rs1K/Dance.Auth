using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.UpdateStudentRegistration;

public record UpdateStudentRegistrationCommand(Guid studentRegistrationId, StudentRegistrationRequestDto studentRegistrationRequestDto) : IRequest;