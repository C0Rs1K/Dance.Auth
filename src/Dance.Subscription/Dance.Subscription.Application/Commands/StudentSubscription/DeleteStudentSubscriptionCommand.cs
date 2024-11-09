using MediatR;

namespace Dance.Subscription.Application.Commands.StudentSubscription;

public record DeleteStudentSubscriptionCommand(string Id) : IRequest;