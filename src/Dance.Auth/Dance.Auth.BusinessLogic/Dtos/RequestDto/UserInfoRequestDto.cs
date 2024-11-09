namespace Dance.Auth.BusinessLogic.Dtos.RequestDto;

public class UserInfoRequestDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public List<string> Roles { get; set; } 
}