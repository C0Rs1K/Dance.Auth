using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Commands.Subscription;

public record CreateSubscriptionCommand(SubscriptionRequestDto SubscriptionRequestDto)
    : IRequest<SubscriptionResponseDto>;