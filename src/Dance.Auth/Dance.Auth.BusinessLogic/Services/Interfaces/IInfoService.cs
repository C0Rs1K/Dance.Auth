using Dance.Auth.BusinessLogic.Dtos;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface IInfoService
{
    Task<UserInfoDto> GetUserInfo(string userName);
}