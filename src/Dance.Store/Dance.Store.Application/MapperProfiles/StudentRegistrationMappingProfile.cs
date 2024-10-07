using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class StudentRegistrationMappingProfile : Profile
{
    public StudentRegistrationMappingProfile()
    {
        CreateMap<StudentRegistrationRequestDto, StudentRegistration>()
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));

        CreateMap<StudentRegistration, StudentRegistrationResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
            .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name))
            .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name));
    }
}