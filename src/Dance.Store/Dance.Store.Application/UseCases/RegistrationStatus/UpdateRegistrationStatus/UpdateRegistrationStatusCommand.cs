using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.UpdateRegistrationStatus;

public record UpdateRegistrationStatusCommand(Guid RegistrationStatusId, RegistrationStatusRequestDto RegistrationStatusRequestDto) : IRequest<RegistrationStatusResponseDto>;