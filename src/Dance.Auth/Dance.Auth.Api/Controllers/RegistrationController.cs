using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Auth.Api.Controllers;

[ApiController]
[Route("api")]
public class LoginController(IRegistrationService registrationService) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequest)
    {
        await registrationService.RegisterUser(registrationRequest);
        return Ok();
    }
}