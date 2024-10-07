using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.CreateRegistrationStatus;

public record CreateRegistrationStatusCommand(RegistrationStatusRequestDto RegistrationStatusRequestDto) : IRequest<RegistrationStatusResponseDto>;