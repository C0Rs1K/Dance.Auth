using Dance.Auth.BusinessLogic.Dtos;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Auth.Api.Controllers;

[ApiController]
[Route("api")]
public class RegistrationController(IRegistrationService registrationService) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequest, CancellationToken cancellationToken)
    {
        await registrationService.RegisterUserAsync(registrationRequest, cancellationToken);
        return Ok();
    }
}