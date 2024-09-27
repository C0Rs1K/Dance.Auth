using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.DeleteStudent;

public class DeleteStudentHandler(IStudentRepository studentRepository) : IRequestHandler<DeleteStudentCommand>
{
    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetFirstAsync(x => x.Id == request.studentId, cancellationToken);
        NotFoundException.ThrowIfNull(student);
        studentRepository.Delete(student);
        await studentRepository.SaveChangesAsync(cancellationToken);
    }
}