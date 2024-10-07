using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.GetStudentById;

public class GetStudentByIdHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<GetStudentByIdCommand, StudentResponseDto>
{
    public async Task<StudentResponseDto> Handle(GetStudentByIdCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == request.StudentId, cancellationToken);
        NotFoundException.ThrowIfNull(student);

        return mapper.Map<StudentResponseDto>(student);
    }
}