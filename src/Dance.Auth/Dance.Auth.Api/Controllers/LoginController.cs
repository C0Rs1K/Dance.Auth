using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
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
        await loginService.Login(registrationRequest, useCookies, useSessionCookies);
        // The signInManager already produced the needed response.
        return this.Empty;
    }
        [HttpPost("Login")]
    public async Task<IActionResult> Logout()
    {
        await loginService.Logout();
        return Ok();
    }
}