using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<StudentRequestDto, Student>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));

        CreateMap<Student, StudentResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Instagram, opt => opt.MapFrom(src => src.Instagram))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
    }
}