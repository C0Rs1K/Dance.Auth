namespace Dance.Subscription.Application.Dtos.RequestDto;

public class StudentRequestDto
{
    public string Name { get; set; } 
    public List<string> SubscriptionIds { get; set; }
}