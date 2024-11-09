using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Queries.Student;

public record GetAllStudentsQuery : IRequest<List<StudentResponseDto>>;