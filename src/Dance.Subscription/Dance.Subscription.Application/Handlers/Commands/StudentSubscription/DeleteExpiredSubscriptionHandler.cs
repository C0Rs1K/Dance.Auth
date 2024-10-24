using AutoMapper;
using Dance.Subscription.Application.Commands.StudentSubscription;
using Dance.Subscription.Domain.Interfaces;
using MediatR;
using DateTime = System.DateTime;

namespace Dance.Subscription.Application.Handlers.Commands.StudentSubscription;

public class DeleteExpiredSubscriptionHandler(IStudentSubscriptionRepository studentSubscriptionRepository, IMapper mapper) : 
    IRequestHandler<DeleteExpiredSubscriptionCommand>
{
    private const int ValidityPeriodInDays = 30;

    public async Task Handle(DeleteExpiredSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var expiredSubscriptions = await studentSubscriptionRepository.GetRangeAsync(x =>
                x.RemainingClasses < 1 ||
                x.CreatedDate.AddDays(ValidityPeriodInDays) < DateTime.Now,
            cancellationToken);

        foreach (var expiredSubscription in expiredSubscriptions)
        {
            await studentSubscriptionRepository.DeleteAsync(expiredSubscription.Id.ToString(), cancellationToken);
        }
    }
}