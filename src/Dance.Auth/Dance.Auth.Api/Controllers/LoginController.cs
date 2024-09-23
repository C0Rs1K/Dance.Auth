using Dance.Auth.BusinessLogic.Dtos;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Dance.Auth.Api.Controllers;

[ApiController]
[Route("api")]
public class LoginController(ILoginService loginService) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto registrationRequest, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies)
    {
        await loginService.LoginAsync(registrationRequest, useCookies, useSessionCookies);
        // The signInManager already produced the needed response.
        return Empty;
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await loginService.LogoutAsync();
        return Ok();
    }
}