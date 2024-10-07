using MediatR;

namespace Dance.Subscription.Application.Commands.Subscription;

public record DeleteSubscriptionCommand(string Id) : IRequest;