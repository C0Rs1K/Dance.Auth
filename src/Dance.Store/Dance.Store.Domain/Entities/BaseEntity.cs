using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
}