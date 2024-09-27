using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class StudentEntity : BaseEntityWithName
{
    [MaxLength(64)]
    public string? Instagram { get; set; }
    [MaxLength(16)]
    public string Phone { get; set; }
}