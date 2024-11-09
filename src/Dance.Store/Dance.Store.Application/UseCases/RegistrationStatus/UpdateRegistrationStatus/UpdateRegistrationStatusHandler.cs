using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.UpdateRegistrationStatus;

public class UpdateRegistrationStatusHandler(IRegistrationStatusRepository registrationStatusRepository, IMapper mapper) : IRequestHandler<UpdateRegistrationStatusCommand, RegistrationStatusResponseDto>
{
    public async Task<RegistrationStatusResponseDto> Handle(UpdateRegistrationStatusCommand request, CancellationToken cancellationToken)
    {
        var registrationStatus =
            await registrationStatusRepository.GetFirstAsync(x => x.Id == request.RegistrationStatusId,
                cancellationToken);
        NotFoundException.ThrowIfNull(registrationStatus);
        var registrationStatusDto = request.RegistrationStatusRequestDto;
        mapper.Map(registrationStatusDto, registrationStatus);
        registrationStatusRepository.Update(registrationStatus);
        await registrationStatusRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<RegistrationStatusResponseDto>(registrationStatus);
    }
}