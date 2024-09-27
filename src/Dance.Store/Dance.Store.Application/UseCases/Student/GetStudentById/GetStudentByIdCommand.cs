using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.GetStudentById;

public record GetStudentByIdCommand(Guid studentId) : IRequest<StudentResponseDto>;