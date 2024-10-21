using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Queries.StudentSubscription;

public record GetAllStudentSubscriptionsQuery : IRequest<List<StudentSubscriptionResponseDto>>;