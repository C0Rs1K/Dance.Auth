using Dance.Auth.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Dance.Auth.Business.Services;

public class RegistrationService(UserManager<User> userManager, IUserStore<User> userStore) : IRegistrationService
{
    public Task RegisterUser(RegistrationRequestDto registrationRequest, CancellationToken cancellationToken)
    {
        var emailStore = (IUserEmailStore<TUser>)userStore;
        var email = registrationRequest.Email;
        
        var user = new User();
        await userStore.SetUserNameAsync(user, email, cancellationToken);
        await emailStore.SetEmailAsync(user, email, cancellationToken);

        var result = await userManager.CreateAsync(user, registrationRequest.Password);

        if (!result.Succeeded)
        {
            throw new BadRequestException("Error occured while creating user")
        }
        else
        {
            userManager.AddToRole(user.Id, "User")
        }
    }
}