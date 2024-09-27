﻿using Dance.Auth.BusinessLogic.Dtos;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Dance.Auth.BusinessLogic.Services;

public class InfoService(UserManager<User> userManager) : IInfoService
{
    public async Task<UserInfoDto> GetUserInfo(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        var userRoles = await userManager.GetRolesAsync(user);

        return new UserInfoDto
        {
            Name = user.Name,
            Email = user.Email,
            Roles = [..userRoles]
        };
    }
}