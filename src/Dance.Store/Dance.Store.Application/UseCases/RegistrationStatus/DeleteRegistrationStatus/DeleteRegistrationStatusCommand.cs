using MediatR;

namespace Dance.Store.Application.UseCases.RegistrationStatus.DeleteRegistrationStatus;

public record DeleteRegistrationStatusCommand(Guid RegistrationStatusId) : IRequest;  