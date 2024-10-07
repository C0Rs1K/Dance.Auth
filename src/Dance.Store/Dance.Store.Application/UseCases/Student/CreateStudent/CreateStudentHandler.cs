using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.CreateStudent;

public class CreateStudentHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<CreateStudentCommand, StudentResponseDto>
{
    public async Task<StudentResponseDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var studentRequestDto = request.StudentRequestDto;
        var student = mapper.Map<Domain.Entities.Student>(studentRequestDto);
        studentRepository.Create(student);
        await studentRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<StudentResponseDto>(student);
    }
}