using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Commands.Subscription;

public record UpdateSubscriptionCommand(string Id, SubscriptionRequestDto SubscriptionRequestDto)
    : IRequest<SubscriptionResponseDto>;