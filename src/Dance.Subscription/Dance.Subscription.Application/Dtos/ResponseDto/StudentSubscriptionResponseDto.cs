namespace Dance.Subscription.Application.Dtos.ResponseDto;

public class StudentSubscriptionResponseDto
{
    public string Id { get; set; }
    public string SubscriptionId { get; set; }
    public string StudentId { get; set; }
    public int RemainingClasses { get; set; }
    public DateTime CreatedDate { get; set; }
}