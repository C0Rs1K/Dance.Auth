using Dance.Auth.BusinessLogic.Dtos.ResponseDto;
using Dance.Auth.BusinessLogic.Enums;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetUsersAsync();
    Task AddRoleAsync(string username, Roles role);
    Task RemoveRoleAsync(string username, Roles role);
    Task DeleteUserAsync(string username);
}