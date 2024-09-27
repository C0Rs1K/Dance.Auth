using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.CreateRegistrationStatus;

public record CreateRegistrationStatusCommand(RegistrationStatusRequestDto registrationStatusRequestDto) : IRequest<Guid>;