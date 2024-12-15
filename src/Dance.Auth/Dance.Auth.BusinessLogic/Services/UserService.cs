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
    public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
    {
        var users = await userManager.Users.ToListAsync();

        var userDtos = new List<UserResponseDto>();

        foreach (var user in users)
        {
            var roles = await userManager.GetRolesAsync(user);

            userDtos.Add(new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Name = user.Name,
                Roles = roles.ToList() 
            });
        }

        return userDtos;
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

    public async Task RemoveRoleAsync(string username, Roles role)
    {
        var user = await userManager.FindByNameAsync(username);

        NotFoundException.ThrowIfNull(user);

        await userManager.RemoveFromRoleAsync(user, role.GetDescription());

        var roles = await userManager.GetRolesAsync(user);

        if (roles.Any() == false)
        {
            await userManager.AddToRoleAsync(user, Roles.User.GetDescription());
        }
    }
}