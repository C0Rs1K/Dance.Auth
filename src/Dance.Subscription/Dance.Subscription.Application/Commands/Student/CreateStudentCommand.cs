using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Commands.Student;

public record CreateStudentCommand(StudentRequestDto StudentRequestDto) : IRequest<StudentResponseDto>;