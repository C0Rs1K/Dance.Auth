using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.StudentRegistration.DeleteStudentRegistration;

public class DeleteStudentRegistrationHandler(IStudentRegistrationRepository studentRegistrationRepository) : IRequestHandler<DeleteStudentRegistrationCommand>
{
    public async Task Handle(DeleteStudentRegistrationCommand request, CancellationToken cancellationToken)
    {
        var studentRegistration =
            await studentRegistrationRepository.GetFirstAsync(x => x.Id == request.studentRegistrationId,
                cancellationToken);
        NotFoundException.ThrowIfNull(studentRegistration);
        studentRegistrationRepository.Delete(studentRegistration);
        await studentRegistrationRepository.SaveChangesAsync(cancellationToken);
    }
}