using Dance.Subscription.Domain.Entities;
using Dance.Subscription.Domain.Interfaces;
using MongoDB.Driver;

namespace Dance.Subscription.infrastructure.Repositories;

public class StudentSubscriptionRepository(IMongoDatabase database) : BaseRepository<StudentSubscription>(database), IStudentSubscriptionRepository
{
    protected override string CollectionName => "StudentSubscriptions";
}