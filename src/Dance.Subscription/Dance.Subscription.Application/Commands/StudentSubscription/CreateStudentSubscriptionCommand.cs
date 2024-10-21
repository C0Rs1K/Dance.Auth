using Dance.Subscription.Application.Dtos.RequestDto;
using Dance.Subscription.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Subscription.Application.Commands.StudentSubscription;

public record CreateStudentSubscriptionCommand(StudentSubscriptionRequestDto StudentSubscriptionRequestDto)
    : IRequest<StudentSubscriptionResponseDto>;