using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.UpdateStudent;

public class UpdateStudentHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<UpdateStudentCommand, StudentResponseDto>
{
    public async Task<StudentResponseDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == request.StudentId, cancellationToken);
        NotFoundException.ThrowIfNull(student);
        var studentDto = request.StudentRequestDto;
        mapper.Map(studentDto, student);
        studentRepository.Update(student);
        await studentRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<StudentResponseDto>(student);
    }
}