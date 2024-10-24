using AutoMapper;
using Dance.Subscription.Application.Commands.StudentSubscription;
using Dance.Subscription.Application.Dtos.ResponseDto;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands.StudentSubscription;

public class UpdateStudentSubscriptionHandler(IStudentSubscriptionRepository studentSubscriptionRepository, IMapper mapper) : 
    IRequestHandler<UpdateStudentSubscriptionCommand, StudentSubscriptionResponseDto>
{
    public async Task<StudentSubscriptionResponseDto> Handle(UpdateStudentSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var studentSubscription =
            await studentSubscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(studentSubscription);
        mapper.Map(request.StudentSubscriptionRequestDto, studentSubscription);
        await studentSubscriptionRepository.UpdateAsync(request.Id, studentSubscription, cancellationToken);

        return mapper.Map<StudentSubscriptionResponseDto>(studentSubscription);
    }
}