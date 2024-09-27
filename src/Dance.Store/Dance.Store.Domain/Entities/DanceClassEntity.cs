using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class DanceClassEntity : BaseEntityWithName
{
    public Guid TrainerId { get; set; }
    public int  ClassDuration { get; set; }
    public int Price { get; set; }
    public int NumberOfPlaces { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public virtual TrainerEntity Trainer { get; set; }
}