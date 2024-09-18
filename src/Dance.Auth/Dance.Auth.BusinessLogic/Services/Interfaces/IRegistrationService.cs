namespace Dance.Auth.Business.Services.Interfaces;

public interface IRegistrationService
{
    Task RegisterUser(RegistrationRequestDto registrationRequest);
}
