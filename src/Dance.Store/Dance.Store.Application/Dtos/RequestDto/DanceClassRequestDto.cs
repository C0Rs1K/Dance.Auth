namespace Dance.Store.Application.Dtos.RequestDto;

public class DanceClassRequestDto
{
    public string Name { get; set; }
    public Guid TrainerId { get; set; }
    public int ClassDuration { get; set; }
    public int Price { get; set; }
    public int NumberOfPlaces { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
}