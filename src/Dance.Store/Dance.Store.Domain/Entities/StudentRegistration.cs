using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class StudentRegistration : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid ClassId { get; set; }
    public Guid StatusId { get; set; }
    public virtual Student Student { get; set; }
    public virtual DanceClass Class { get; set; }
    public virtual RegistrationStatus Status { get; set; }
}