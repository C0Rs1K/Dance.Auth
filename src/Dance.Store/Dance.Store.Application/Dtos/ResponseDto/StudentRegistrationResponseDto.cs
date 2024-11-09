namespace Dance.Store.Application.Dtos.ResponseDto;

public class StudentRegistrationResponseDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ClassId { get; set; }
    public Guid StatusId { get; set; }
    public string StudentName { get; set; }
    public string ClassName { get; set; }
    public string StatusName { get; set; }
}