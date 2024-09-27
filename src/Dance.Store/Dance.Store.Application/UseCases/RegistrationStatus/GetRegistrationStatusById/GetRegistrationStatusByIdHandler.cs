using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Application.Exceptions;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.GetRegistrationStatusById;

public class GetRegistrationStatusByIdHandler(IRegistrationStatusRepository registrationStatusRepository, IMapper mapper) : IRequestHandler<GetRegistrationStatusByIdCommand, RegistrationStatusResponseDto>
{
    public async Task<RegistrationStatusResponseDto> Handle(GetRegistrationStatusByIdCommand request, CancellationToken cancellationToken)
    {
        var registrationStatus = await 
            registrationStatusRepository.GetFirstAsync(x => x.Id == request.registrationStatusId, cancellationToken);
        NotFoundException.ThrowIfNull(registrationStatus);
        return mapper.Map<RegistrationStatusResponseDto>(registrationStatus);
    }
}