using Dance.Auth.BusinessLogic.Dtos.ResponseDto;
using Dance.Auth.BusinessLogic.Enums;
using Dance.Auth.BusinessLogic.Exceptions;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dance.Auth.BusinessLogic.Services;

public class UserService(UserManager<User> userManager) : IUserService
{
    public IEnumerable<UserResponseDto> GetUsers()
    {
        var users = userManager.Users;

        return users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            Name = user.Name    
        }).ToList();
    }

    public async Task AddRoleAsync(string username, Roles role)
    {
        var user = await userManager.FindByNameAsync(username);
        NotFoundException.ThrowIfNull(user);
        await userManager.AddToRoleAsync(user, role.GetDescription());
    }

    public async Task DeleteUserAsync(string username)
    {
        var user = await userManager.FindByNameAsync(username);
        NotFoundException.ThrowIfNull(user);
        await userManager.DeleteAsync(user);
    }
}