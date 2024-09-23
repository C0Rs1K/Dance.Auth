namespace Dance.Auth.BusinessLogic.Dtos;

public class UserInfoDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public List<string> Roles { get; set; } 
}