using Dance.Auth.BusinessLogic.Dtos.RequestDto;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface IInfoService
{
    Task<UserInfoRequestDto> GetUserInfo(string userName);
}