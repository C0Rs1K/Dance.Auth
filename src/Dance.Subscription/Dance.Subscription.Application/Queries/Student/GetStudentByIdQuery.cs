using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Queries.Student;

public record GetStudentByIdQuery(string Id) : IRequest<StudentResponseDto>;