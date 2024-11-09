namespace Dance.Subscription.Domain.Entities;

public class Subscription : BaseEntity
{
    public int NumberOfClasses { get; set; }
    public int ValidityPeriodInDays { get; set; }
}