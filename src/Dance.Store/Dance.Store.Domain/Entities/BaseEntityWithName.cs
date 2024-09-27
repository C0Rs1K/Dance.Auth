using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class BaseEntityWithName : BaseEntity
{
    [MaxLength(128)]
    public string Name { get; set; }
}