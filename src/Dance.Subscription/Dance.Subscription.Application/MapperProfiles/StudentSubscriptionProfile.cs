using AutoMapper;
using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Domain.Entities;
using MongoDB.Bson;

namespace Dance.Subscription.Application.MapperProfiles;

public class StudentSubscriptionProfile : Profile
{
    public StudentSubscriptionProfile()
    {
        CreateMap<StudentSubscriptionRequestDto, StudentSubscription>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => new ObjectId(src.StudentId)))
            .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => new ObjectId(src.SubscriptionId)))
            .ForMember(dest => dest.RemainingClasses, opt => opt.MapFrom(src => src.RemainingClasses))
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

        CreateMap<StudentSubscription, StudentSubscriptionResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.SubscriptionId.ToString()))
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId.ToString()))
            .ForMember(dest => dest.RemainingClasses, opt => opt.MapFrom(src => src.RemainingClasses))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
    }
}