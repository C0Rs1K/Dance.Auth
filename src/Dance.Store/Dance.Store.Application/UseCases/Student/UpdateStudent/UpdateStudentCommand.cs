using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.UpdateStudent;

public record UpdateStudentCommand(Guid studentId, StudentRequestDto studentRequestDto) : IRequest;