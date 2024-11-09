using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.Student.ProcessStudentRegistration;

public class ProcessStudentRegistrationHandler(IStudentRepository studentRepository) : IRequestHandler<ProcessStudentRegistrationCommand>
{
    public async Task Handle(ProcessStudentRegistrationCommand request, CancellationToken cancellationToken)
    {
        var student = request.Student;

        var existedStudent = await studentRepository.GetFirstAsync(x => 
            x.Name == student.Name && 
            x.Phone == student.Phone, 
            cancellationToken);

        if (existedStudent == null)
        {
            studentRepository.Create(student);

            await studentRepository.SaveChangesAsync(cancellationToken);
        }
    }
}