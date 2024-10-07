using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class RegistrationStatusMappingProfile : Profile
{
    public RegistrationStatusMappingProfile()
    {
        CreateMap<RegistrationStatusRequestDto, RegistrationStatus>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<RegistrationStatus, RegistrationStatusResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}