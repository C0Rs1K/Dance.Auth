using Dance.Auth.BusinessLogic.Dtos;
using Dance.Auth.BusinessLogic.Dtos.RequestDto;
using Dance.Auth.BusinessLogic.Enums;
using Dance.Auth.BusinessLogic.Exceptions;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Dance.Auth.BusinessLogic.Services;

public class RegistrationService(UserManager<User> userManager, IUserStore<User> userStore) : IRegistrationService
{
    public async Task RegisterUserAsync(RegistrationRequestDto registrationRequest, CancellationToken cancellationToken)
    {
        var emailStore = (IUserEmailStore<User>)userStore;
        var email = registrationRequest.Email;
        
        var user = new User();
        await userStore.SetUserNameAsync(user, email, cancellationToken);
        await emailStore.SetEmailAsync(user, email, cancellationToken);
        user.Name = registrationRequest.Name;

        var existedUser = await userManager.FindByNameAsync(email);
        AlreadyExistException.ThrowIfNotNull(existedUser);

        var result = await userManager.CreateAsync(user, registrationRequest.Password);
            
        if (!result.Succeeded)
        {
            throw new BadRequestException($"Error occured while creating user: {string.Join(";\n", 
                result.Errors.Select(x => x.Description))}");
        }
        
        await userManager.AddToRoleAsync(user, Roles.User.GetDescription());
    }
}