using AutoMapper;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Application.Queries.StudentSubscription;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Queries.StudentSubscription;

public class GetStudentSubscriptionByIdHandler(IStudentSubscriptionRepository studentSubscriptionRepository, IMapper mapper) : 
    IRequestHandler<GetStudentSubscriptionByIdQuery, StudentSubscriptionResponseDto>
{
    public async Task<StudentSubscriptionResponseDto> Handle(GetStudentSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var studentSubscription = await studentSubscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(studentSubscription);

        return mapper.Map<StudentSubscriptionResponseDto>(studentSubscription);
    }
}