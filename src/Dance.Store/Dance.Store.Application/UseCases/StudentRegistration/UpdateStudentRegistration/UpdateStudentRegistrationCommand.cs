using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.UpdateStudentRegistration;

public record UpdateStudentRegistrationCommand(Guid StudentRegistrationId, StudentRegistrationRequestDto StudentRegistrationRequestDto) : IRequest<StudentRegistrationResponseDto>;