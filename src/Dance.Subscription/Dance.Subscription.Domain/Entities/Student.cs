namespace Dance.Subscription.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public virtual List<StudentSubscription> Subscriptions { get; set; }
}