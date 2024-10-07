using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.GetRegistrationStatusById;

public record GetRegistrationStatusByIdCommand(Guid RegistrationStatusId) : IRequest<RegistrationStatusResponseDto>;