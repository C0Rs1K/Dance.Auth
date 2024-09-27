using AutoMapper;
using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.CreateStudent;

public class CreateStudentHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<CreateStudentCommand, Guid>
{
    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var studentRequestDto = request.studentRequestDto;
        var student = mapper.Map<StudentEntity>(studentRequestDto);
        studentRepository.Create(student);
        await studentRepository.SaveChangesAsync(cancellationToken);
        return student.Id;
    }
}