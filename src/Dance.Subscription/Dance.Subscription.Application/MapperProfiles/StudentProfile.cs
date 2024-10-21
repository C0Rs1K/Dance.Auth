using AutoMapper;
using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Domain.Entities;

namespace Dance.Subscription.Application.MapperProfiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<StudentRequestDto, Student>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Subscriptions, opt => opt.Ignore());

        CreateMap<Student, StudentResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Subscriptions, opt => opt.MapFrom(src => src.Subscriptions));
    }
}