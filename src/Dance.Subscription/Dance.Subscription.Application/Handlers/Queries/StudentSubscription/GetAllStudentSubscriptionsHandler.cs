using AutoMapper;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Queries.StudentSubscription;
using Dance.Subscription.Domain.Interfaces;
using MediatR;

namespace Dance.Subscription.Application.Handlers.Queries.StudentSubscription;

public class GetAllStudentSubscriptionsHandler(IStudentSubscriptionRepository studentSubscriptionRepository, IMapper mapper) : 
    IRequestHandler<GetAllStudentSubscriptionsQuery, List<StudentSubscriptionResponseDto>>
{
    public async Task<List<StudentSubscriptionResponseDto>> Handle(GetAllStudentSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var studentSubscriptions = await studentSubscriptionRepository.GetRangeAsync(x => true, cancellationToken);

        return mapper.Map<List<StudentSubscriptionResponseDto>>(studentSubscriptions);
    }
}