using AutoMapper;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Application.UseCases.RegistrationStatus.GetAllRegistrationStatuses;

public class GetAllRegistrationStatusesHandler(IRegistrationStatusRepository registrationStatusRepository, IMapper mapper) : IRequestHandler<GetAllRegistrationStatusesCommand, IEnumerable<RegistrationStatusResponseDto>>
{
    public async Task<IEnumerable<RegistrationStatusResponseDto>> Handle(GetAllRegistrationStatusesCommand request, CancellationToken cancellationToken)
    {
        var registrationStatuses = registrationStatusRepository.GetRange(x => true, cancellationToken);
        return await mapper.ProjectTo<RegistrationStatusResponseDto>(registrationStatuses).ToListAsync(cancellationToken);
    }
}