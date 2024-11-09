using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.DeleteRegistrationStatus;

public class DeleteRegistrationStatusHandler(IRegistrationStatusRepository registrationStatusRepository) : IRequestHandler<DeleteRegistrationStatusCommand>
{
    public async Task Handle(DeleteRegistrationStatusCommand request, CancellationToken cancellationToken)
    {
        var registrationStatus =
            await registrationStatusRepository.GetFirstAsync(x => x.Id == request.RegistrationStatusId, cancellationToken);
        NotFoundException.ThrowIfNull(registrationStatus);
        registrationStatusRepository.Delete(registrationStatus);
        await registrationStatusRepository.SaveChangesAsync(cancellationToken);
    }
}