using AutoMapper;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Queries.Subscription;
using Dance.Subscription.Domain.Interfaces;
using MediatR;

namespace Dance.Subscription.Application.Handlers.Queries.Subscription;

public class GetAllSubscriptionsHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper) :
    IRequestHandler<GetAllSubscriptionsQuery, List<SubscriptionResponseDto>>
{
    public async Task<List<SubscriptionResponseDto>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var subscriptions = await subscriptionRepository.GetRangeAsync(x => true, cancellationToken);

        return mapper.Map<List<SubscriptionResponseDto>>(subscriptions);
    }
}