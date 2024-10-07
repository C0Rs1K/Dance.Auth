using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.CreateStudent;

public record CreateStudentCommand(StudentRequestDto StudentRequestDto) : IRequest<StudentResponseDto>;