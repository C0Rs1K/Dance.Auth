namespace Dance.Store.Application.Dtos.RequestDto;

public class StudentRegistrationRequestDto
{
    public Guid StudentId { get; set; }
    public Guid ClassId { get; set; }
    public Guid StatusId { get; set; }
}