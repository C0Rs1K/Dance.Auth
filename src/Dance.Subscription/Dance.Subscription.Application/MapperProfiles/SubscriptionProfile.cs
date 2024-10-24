using AutoMapper;
using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;

namespace Dance.Subscription.Application.MapperProfiles;

public class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<SubscriptionRequestDto, Domain.Entities.Subscription>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.NumberOfClasses, opt => opt.MapFrom(src => src.NumberOfClasses));
        CreateMap<Domain.Entities.Subscription, SubscriptionResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.NumberOfClasses, opt => opt.MapFrom(src => src.NumberOfClasses));
    }
}