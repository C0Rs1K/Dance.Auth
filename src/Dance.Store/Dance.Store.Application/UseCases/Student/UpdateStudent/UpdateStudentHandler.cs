using AutoMapper;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.UpdateStudent;

public class UpdateStudentHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<UpdateStudentCommand>
{
    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == request.studentId, cancellationToken);
        NotFoundException.ThrowIfNull(student);
        var studentDto = request.studentRequestDto;
        mapper.Map(studentDto, student);
        studentRepository.Update(student);
        await studentRepository.SaveChangesAsync(cancellationToken);
    }
}