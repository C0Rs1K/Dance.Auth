using System.ComponentModel.DataAnnotations;

namespace Dance.Store.Domain.Entities;

public class StudentRegistrationEntity : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid ClassId { get; set; }
    public Guid StatusId { get; set; }
    public virtual StudentEntity Student { get; set; }
    public virtual DanceClassEntity Class { get; set; }
    public virtual RegistrationStatusEntity Status { get; set; }
}