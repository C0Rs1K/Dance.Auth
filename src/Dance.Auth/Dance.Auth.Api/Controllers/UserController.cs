using Dance.Auth.BusinessLogic.Enums;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Auth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers(CancellationToken cancellationToken)
    { 
        var users = userService.GetUsers();

        return Ok(users);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserAsync(string username, CancellationToken cancellationToken)
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

}