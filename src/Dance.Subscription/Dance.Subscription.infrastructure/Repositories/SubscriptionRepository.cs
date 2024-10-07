using Dance.Subscription.Domain.Interfaces;
using MongoDB.Driver;

namespace Dance.Subscription.infrastructure.Repositories;

public class SubscriptionRepository(IMongoDatabase database) : BaseRepository<Domain.Entities.Subscription>(database), ISubscriptionRepository
{
    protected override string CollectionName => "Subscriptions";
}