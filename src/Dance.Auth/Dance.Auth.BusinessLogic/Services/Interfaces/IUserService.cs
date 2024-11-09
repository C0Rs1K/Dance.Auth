using Dance.Auth.BusinessLogic.Dtos.ResponseDto;
using Dance.Auth.BusinessLogic.Enums;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface IUserService
{
    IEnumerable<UserResponseDto> GetUsers();
    Task AddRoleAsync(string username, Roles role);
    Task DeleteUserAsync(string username);
}