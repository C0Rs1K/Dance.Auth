using AutoMapper;
using Dance.Subscription.Application.Commands.Subscription;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Domain.Interfaces;
using MediatR;

namespace Dance.Subscription.Application.Handlers.Commands.Subscription;

public class CreateSubscriptionHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper) : IRequestHandler<CreateSubscriptionCommand, SubscriptionResponseDto>
{
    public async Task<SubscriptionResponseDto> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = mapper.Map<Domain.Entities.Subscription>(request.SubscriptionRequestDto);
        await subscriptionRepository.CreateAsync(subscription, cancellationToken);

        return mapper.Map<SubscriptionResponseDto>(subscription);
    }
}