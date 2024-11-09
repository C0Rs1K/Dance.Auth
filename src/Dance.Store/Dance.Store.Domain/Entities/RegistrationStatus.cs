using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class RegistrationStatus : BaseEntity
{
    public string Name { get; set; }
}