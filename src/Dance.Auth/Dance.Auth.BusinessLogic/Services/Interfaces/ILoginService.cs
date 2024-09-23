using Dance.Auth.BusinessLogic.Dtos;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface ILoginService
{
    Task LoginAsync(LoginRequestDto registrationRequest, bool? useCookies, bool? useSessionCookies);
    Task LogoutAsync();
}
