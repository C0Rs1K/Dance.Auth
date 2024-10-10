using Dance.Auth.BusinessLogic.Dtos.RequestDto;
using Dance.Auth.BusinessLogic.Exceptions;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.DataAccess.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Dance.Auth.BusinessLogic.Services;

public class LoginService(SignInManager<User> signInManager, IOptionsMonitor<BearerTokenOptions> bearerTokenOptions) : ILoginService
{
    public async Task LoginAsync(LoginRequestDto loginRequest, bool? useCookies, bool? useSessionCookies)
    {
        var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
        var isPersistent = (useCookies == true) && (useSessionCookies != true);
        signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

        var result = await signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, isPersistent, lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            throw new UnauthorizedException("Incorrect username or password");
        }
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }

    public async Task<ClaimsPrincipal> Refresh(RefreshRequestDto refreshRequest)
    {
        var refreshTokenProtector = bearerTokenOptions.Get(IdentityConstants.BearerScheme).RefreshTokenProtector;
        var refreshTicket = refreshTokenProtector.Unprotect(refreshRequest.RefreshToken);

        if (refreshTicket?.Properties?.ExpiresUtc is not { } expiresUtc ||
            DateTime.UtcNow >= expiresUtc ||
            await signInManager.ValidateSecurityStampAsync(refreshTicket.Principal) is not User user)
        {
            throw new UnauthorizedException("Refresh token is not valid");
        }

        var newPrincipal = await signInManager.CreateUserPrincipalAsync(user);

        return newPrincipal;
    }
}