namespace Dance.Subscription.Application.Dtos.RequestDto;

public class StudentSubscriptionRequestDto
{
    public string SubscriptionId { get; set; }
    public string StudentId { get; set; }
    public int RemainingClasses { get; set; }
}