using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class TrainerMappingProfile : Profile
{
    public TrainerMappingProfile()
    {
        CreateMap<TrainerRequestDto, Trainer>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.DanceClasses, opt => opt.Ignore()); 

        CreateMap<Trainer, TrainerResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
    }
}