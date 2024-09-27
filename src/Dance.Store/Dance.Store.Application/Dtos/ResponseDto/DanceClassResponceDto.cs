namespace Dance.Store.Application.Dtos.ResponseDto;

public class DanceClassResponseDto
{
    public Guid Id { get; set; } 
    public string Name { get; set; } 
    public Guid TrainerId { get; set; }
    public string TrainerName { get; set; } 
    public int ClassDuration { get; set; }
    public int Price { get; set; }
    public int NumberOfPlaces { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
}