using Dance.Auth.BusinessLogic.Dtos.RequestDto;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Dance.Auth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController(ILoginService loginService) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto registrationRequest, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies, CancellationToken cancellationToken)
    {
        await loginService.LoginAsync(registrationRequest, useCookies, useSessionCookies);
        // The signInManager already produced the needed response.
        return Empty;
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        await loginService.LogoutAsync();

        return Ok();
    }

    [HttpPost("Refresh")]
    public async Task<IActionResult> Refresh(RefreshRequestDto refreshRequest, CancellationToken cancellationToken)
    {
        var newPrincipal = await loginService.Refresh(refreshRequest);

        return SignIn(newPrincipal, IdentityConstants.BearerScheme);
    }
}