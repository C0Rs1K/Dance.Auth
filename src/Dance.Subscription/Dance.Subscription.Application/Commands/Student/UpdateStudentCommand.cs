using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Commands.Student;

public record UpdateStudentCommand(string Id, StudentRequestDto StudentRequestDto) : IRequest<StudentResponseDto>;
