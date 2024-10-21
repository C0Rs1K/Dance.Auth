using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Queries.Subscription;

public record GetSubscriptionByIdQuery(string Id) : IRequest<SubscriptionResponseDto>;