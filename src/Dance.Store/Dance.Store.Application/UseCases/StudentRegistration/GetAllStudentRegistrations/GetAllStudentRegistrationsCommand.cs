using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.GetAllStudentRegistrations;

public record GetAllStudentRegistrationsCommand : IRequest<IEnumerable<StudentRegistrationResponseDto>>;