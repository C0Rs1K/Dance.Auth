using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class RegistrationStatusMappingProfile : Profile
{
    public RegistrationStatusMappingProfile()
    {
        CreateMap<RegistrationStatusEntity, RegistrationStatusResponseDto>();
        CreateMap<RegistrationStatusRequestDto, RegistrationStatusEntity>();
    }
}