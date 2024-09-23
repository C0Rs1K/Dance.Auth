namespace Dance.Store.Domain.Entities;

public class StudentRegistrationEntity : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid ClassId { get; set; }
    public Guid StatusId { get; set; }
}