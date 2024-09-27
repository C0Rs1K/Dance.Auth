using Dance.Store.Application.Dtos.RequestDto;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.UpdateRegistrationStatus;

public record UpdateRegistrationStatusCommand(Guid registrationStatusId, RegistrationStatusRequestDto registrationStatusRequestDto) : IRequest;