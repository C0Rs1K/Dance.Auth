using AutoMapper;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Application.Queries.Subscription;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Queries.Subscription;

public class GetSubscriptionByIdHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper) :
    IRequestHandler<GetSubscriptionByIdQuery, SubscriptionResponseDto>
{
    public async Task<SubscriptionResponseDto> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(subscription);

        return mapper.Map<SubscriptionResponseDto>(subscription);
    }
}