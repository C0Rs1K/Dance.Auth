using AutoMapper;
using Dance.Subscription.Application.Commands.StudentSubscription;
using Dance.Subscription.Application.Exceptions;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Dance.Subscription.Application.Handlers.Commands.StudentSubscription;

public class DeleteStudentSubscriptionHandler(IStudentSubscriptionRepository studentSubscriptionRepository, IMapper mapper) : 
    IRequestHandler<DeleteStudentSubscriptionCommand>
{
    public async Task Handle(DeleteStudentSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var studentSubscription = await studentSubscriptionRepository.GetFirstAsync(x => x.Id == new ObjectId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(studentSubscription);
        await studentSubscriptionRepository.DeleteAsync(request.Id, cancellationToken);
    }
}