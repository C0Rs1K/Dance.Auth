namespace Dance.Subscription.Application.Dtos.ResponseDto;

public class SubscriptionResponseDto
{
    public string Id { get; set; }
    public int NumberOfClasses { get; set; }
    public int ValidityPeriodInDays { get; set; }
}