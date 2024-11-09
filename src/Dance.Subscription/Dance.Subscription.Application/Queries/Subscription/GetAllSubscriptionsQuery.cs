using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Queries.Subscription;

public record GetAllSubscriptionsQuery : IRequest<List<SubscriptionResponseDto>>;