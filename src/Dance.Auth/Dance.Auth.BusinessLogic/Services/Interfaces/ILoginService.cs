using Dance.Auth.BusinessLogic.Dtos.RequestDto;
using System.Security.Claims;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface ILoginService
{
    Task LoginAsync(LoginRequestDto registrationRequest, bool? useCookies, bool? useSessionCookies);
    Task LogoutAsync();
    Task<ClaimsPrincipal> Refresh(RefreshRequestDto refreshRequest);
}
