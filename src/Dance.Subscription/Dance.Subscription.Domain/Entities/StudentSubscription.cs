using MongoDB.Bson;

namespace Dance.Subscription.Domain.Entities;

public class StudentSubscription : BaseEntity
{
    public ObjectId StudentId { get; set; }
    public ObjectId SubscriptionId { get; set; } 
    public int RemainingClasses { get; set; }
    public DateTime CreatedDate { get; set; }
}