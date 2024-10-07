using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.UpdateStudent;

public record UpdateStudentCommand(Guid StudentId, StudentRequestDto StudentRequestDto) : IRequest<StudentResponseDto>;