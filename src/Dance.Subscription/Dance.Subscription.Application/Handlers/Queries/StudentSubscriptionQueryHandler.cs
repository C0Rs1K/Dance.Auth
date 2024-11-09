using AutoMapper;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Application.Queries.StudentSubscription;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Queries;

public class StudentSubscriptionQueryHandler(
    IStudentSubscriptionRepository studentSubscriptionRepository,
    IMapper mapper) :
        IRequestHandler<GetStudentSubscriptionByIdQuery, StudentSubscriptionResponseDto>,
        IRequestHandler<GetAllStudentSubscriptionsQuery, List<StudentSubscriptionResponseDto>>
{
    public async Task<StudentSubscriptionResponseDto> Handle(GetStudentSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var studentSubscription = await studentSubscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(studentSubscription);

        return mapper.Map<StudentSubscriptionResponseDto>(studentSubscription);
    }

    public async Task<List<StudentSubscriptionResponseDto>> Handle(GetAllStudentSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var studentSubscriptions = await studentSubscriptionRepository.GetRangeAsync(x => true, cancellationToken);

        return mapper.Map<List<StudentSubscriptionResponseDto>>(studentSubscriptions);
    }
}
