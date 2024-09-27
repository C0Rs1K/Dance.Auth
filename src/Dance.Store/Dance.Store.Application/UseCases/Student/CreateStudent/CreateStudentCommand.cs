using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.CreateStudent;

public record CreateStudentCommand(StudentRequestDto studentRequestDto) : IRequest<Guid>;