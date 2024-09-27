using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class TrainerEntity : BaseEntityWithName
{
    [MaxLength(16)]
    public string Phone { get; set; }
}