using Dance.Auth.BusinessLogic.Enums;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Auth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsersAsync(CancellationToken cancellationToken)
    { 
        var users = await userService.GetUsersAsync();

        return Ok(users);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserAsync([FromQuery] string username, CancellationToken cancellationToken)
    {
        await userService.DeleteUserAsync(username);

        return NoContent();
    }

    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRoleAsync(string username, Roles role, CancellationToken cancellationToken)
    {
        await userService.AddRoleAsync(username, role);

        return Ok();
    }


    [HttpPost("RemoveRole")]
    public async Task<IActionResult> RemoveRoleAsync(string username, Roles role, CancellationToken cancellationToken)
    {
        await userService.RemoveRoleAsync(username, role);

        return Ok();
    }
}