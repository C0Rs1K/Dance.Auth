﻿using AutoMapper;
using Dance.Subscription.Application.Commands.Subscription;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands.Subscription;

public class UpdateSubscriptionHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper) : IRequestHandler<UpdateSubscriptionCommand, SubscriptionResponseDto>
{
    public async Task<SubscriptionResponseDto> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(subscription);
        mapper.Map(request.SubscriptionRequestDto, subscription);
        await subscriptionRepository.UpdateAsync(request.Id, subscription, cancellationToken);

        return mapper.Map<SubscriptionResponseDto>(subscription);
    }
}