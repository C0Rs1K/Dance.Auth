using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.GetAllStudents;

public record GetAllStudentsCommand : IRequest<IEnumerable<StudentResponseDto>>;