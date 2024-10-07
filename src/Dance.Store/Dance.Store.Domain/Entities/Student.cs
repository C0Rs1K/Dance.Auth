using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public string? Instagram { get; set; }
    public string Phone { get; set; }
}