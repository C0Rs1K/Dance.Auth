using AutoMapper;
using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.Dtos.ResponseDto;
using Dance.Store.Domain.Entities;

namespace Dance.Store.Application.MapperProfiles;

public class StudentRegistrationMappingProfile : Profile
{
    public StudentRegistrationMappingProfile()
    {
        CreateMap<StudentRegistrationEntity, StudentRegistrationResponseDto>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
            .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name))
            .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name));

        CreateMap<StudentRegistrationRequestDto, StudentRegistrationEntity>();
    }
}