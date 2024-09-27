using AutoMapper;
using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.CreateRegistrationStatus;

public class CreateRegistrationStatusHandler(IRegistrationStatusRepository registrationStatusRepository, IMapper mapper) : IRequestHandler<CreateRegistrationStatusCommand, Guid>
{
    public async Task<Guid> Handle(CreateRegistrationStatusCommand request, CancellationToken cancellationToken)
    {
        var registrationStatusDto = request.registrationStatusRequestDto;
        var registrationStatus = mapper.Map<RegistrationStatusEntity>(registrationStatusDto);
        registrationStatusRepository.Create(registrationStatus);
        await registrationStatusRepository.SaveChangesAsync(cancellationToken);
        return registrationStatus.Id;
    }
}