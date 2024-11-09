using AutoMapper;
using Dance.Subscription.Application.Commands.Subscription;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands;

public class SubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper) :
        IRequestHandler<CreateSubscriptionCommand, SubscriptionResponseDto>,
        IRequestHandler<UpdateSubscriptionCommand, SubscriptionResponseDto>,
        IRequestHandler<DeleteSubscriptionCommand>
{
    public async Task<SubscriptionResponseDto> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = mapper.Map<Domain.Entities.Subscription>(request.SubscriptionRequestDto);
        await subscriptionRepository.CreateAsync(subscription, cancellationToken);

        return mapper.Map<SubscriptionResponseDto>(subscription);
    }

    public async Task<SubscriptionResponseDto> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(subscription);
        mapper.Map(request.SubscriptionRequestDto, subscription);
        await subscriptionRepository.UpdateAsync(request.Id, subscription, cancellationToken);

        return mapper.Map<SubscriptionResponseDto>(subscription);
    }

    public async Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(subscription);
        await subscriptionRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
