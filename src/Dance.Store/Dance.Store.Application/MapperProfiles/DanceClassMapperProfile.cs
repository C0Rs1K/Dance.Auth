using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class DanceClassMapperProfile : Profile
{
    public DanceClassMapperProfile()
    {
        CreateMap<DanceClassRequestDto, DanceClass>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.TrainerId))
            .ForMember(dest => dest.ClassDuration, opt => opt.MapFrom(src => src.ClassDuration))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.NumberOfPlaces, opt => opt.MapFrom(src => src.NumberOfPlaces))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Trainer, opt => opt.Ignore());

        CreateMap<DanceClass, DanceClassResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.TrainerId))
            .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name))
            .ForMember(dest => dest.ClassDuration, opt => opt.MapFrom(src => src.ClassDuration))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.NumberOfPlaces, opt => opt.MapFrom(src => src.NumberOfPlaces))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
    }
}