using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Commands.StudentSubscription;

public record UpdateStudentSubscriptionCommand(string Id, StudentSubscriptionRequestDto StudentSubscriptionRequestDto)
    : IRequest<StudentSubscriptionResponseDto>;