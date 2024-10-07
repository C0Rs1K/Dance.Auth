using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.GetAllRegistrationStatuses;

public class GetAllRegistrationStatusesHandler(IRegistrationStatusRepository registrationStatusRepository, IMapper mapper) : IRequestHandler<GetAllRegistrationStatusesCommand, IEnumerable<RegistrationStatusResponseDto>>
{
    public async Task<IEnumerable<RegistrationStatusResponseDto>> Handle(GetAllRegistrationStatusesCommand request, CancellationToken cancellationToken)
    {
        var registrationStatuses = registrationStatusRepository.GetRangeAsync(x => true, cancellationToken);

        return mapper.Map<IEnumerable<RegistrationStatusResponseDto>>(registrationStatuses);
    }
}