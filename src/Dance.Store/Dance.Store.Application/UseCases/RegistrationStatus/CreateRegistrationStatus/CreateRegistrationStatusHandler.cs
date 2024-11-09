using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.CreateRegistrationStatus;

public class CreateRegistrationStatusHandler(IRegistrationStatusRepository registrationStatusRepository, IMapper mapper) : IRequestHandler<CreateRegistrationStatusCommand, RegistrationStatusResponseDto>
{
    public async Task<RegistrationStatusResponseDto> Handle(CreateRegistrationStatusCommand request, CancellationToken cancellationToken)
    {
        var registrationStatusDto = request.RegistrationStatusRequestDto;
        var registrationStatus = mapper.Map<Domain.Entities.RegistrationStatus>(registrationStatusDto);
        var status = await registrationStatusRepository.GetFirstAsync(x => x.Name == registrationStatus.Name, cancellationToken);
        AlreadyExistsException.ThrowIfNotNull(status);
        registrationStatusRepository.Create(registrationStatus);    
        await registrationStatusRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<RegistrationStatusResponseDto>(registrationStatus);
    }
}