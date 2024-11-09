using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.GetStudentRegistrationById;

public record GetStudentRegistrationByIdCommand(Guid StudentRegistrationId) : IRequest<StudentRegistrationResponseDto>;