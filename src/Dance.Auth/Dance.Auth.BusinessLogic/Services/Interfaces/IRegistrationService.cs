using Dance.Auth.BusinessLogic.Dtos;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface IRegistrationService
{
    Task RegisterUserAsync(RegistrationRequestDto registrationRequest, CancellationToken cancellationToken);
}
