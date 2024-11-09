namespace Dance.Subscription.Application.Dtos.ResponseDto;

public class StudentResponseDto
{
    public string Id { get; set; } 
    public string Name { get; set; } 
    public List<StudentSubscriptionResponseDto> Subscriptions { get; set; }
}