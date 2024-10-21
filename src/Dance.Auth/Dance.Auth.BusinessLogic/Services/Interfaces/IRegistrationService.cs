using Dance.Auth.BusinessLogic.Dtos.RequestDto;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface IRegistrationService
{
    Task RegisterUserAsync(RegistrationRequestDto registrationRequest, CancellationToken cancellationToken);
}
