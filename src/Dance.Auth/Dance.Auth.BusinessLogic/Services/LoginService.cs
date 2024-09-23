using Dance.Auth.BusinessLogic.Dtos;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Dance.Auth.BusinessLogic.Services;

public class LoginService(SignInManager<User> signInManager) : ILoginService
{
    public async Task LoginAsync(LoginRequestDto loginRequest, bool? useCookies, bool? useSessionCookies)
    {
        var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
        var isPersistent = (useCookies == true) && (useSessionCookies != true);
        signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

        var result = await signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, isPersistent, lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            throw new UnauthorizedAccessException("Incorrect username or password");
        }
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}