using AutoMapper;
using Dance.Subscription.Application.Commands.Subscription;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands.Subscription;

public class DeleteSubscriptionHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper) : IRequestHandler<DeleteSubscriptionCommand>
{
    public async Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(subscription);
        await subscriptionRepository.DeleteAsync(request.Id, cancellationToken);
    }
}