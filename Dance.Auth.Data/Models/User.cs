using Microsoft.AspNetCore.Identity;

namespace Dance.Auth.Data.Models;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
}