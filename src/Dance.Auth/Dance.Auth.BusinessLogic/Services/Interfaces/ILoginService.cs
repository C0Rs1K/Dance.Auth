namespace Dance.Auth.Business.Services.Interfaces;

public interface ILoginService
{
    Task Login(LoginRequestDto registrationRequest, bool? useCookies, bool? useSessionCookies);
    Task Logout();
}
