using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.CreateStudentRegistration;

public record CreateStudentRegistrationCommand(StudentRegistrationRequestDto StudentRegistrationRequestDto) : IRequest<StudentRegistrationResponseDto>;