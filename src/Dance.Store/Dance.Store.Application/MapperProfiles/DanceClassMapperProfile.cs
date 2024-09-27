using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class DanceClassMapperProfile : Profile
{
    public DanceClassMapperProfile()
    {
        CreateMap<DanceClassEntity, DanceClassResponseDto>()
            .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name));

        CreateMap<DanceClassRequestDto, DanceClassEntity>();
    }
}