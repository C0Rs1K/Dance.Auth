using MongoDB.Bson;

namespace Dance.Subscription.Domain.Entities;

public abstract class BaseEntity
{
    public ObjectId Id { get; set; }
}