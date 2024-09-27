using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}