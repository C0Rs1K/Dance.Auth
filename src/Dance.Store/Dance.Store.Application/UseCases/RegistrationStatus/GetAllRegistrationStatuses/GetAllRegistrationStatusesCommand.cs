using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.GetAllRegistrationStatuses;

public record GetAllRegistrationStatusesCommand : IRequest<IEnumerable<RegistrationStatusResponseDto>>;