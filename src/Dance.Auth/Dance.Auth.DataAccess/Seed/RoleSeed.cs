using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dance.Auth.Data.Seed;

public class RoleSeed : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    private readonly string[] _roles = ["User", "Trainer", "Admin"];
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        var roles = _roles.Select(role => new IdentityRole<Guid>(role)
        {
            Id = Guid.NewGuid(), 
            NormalizedName = role.ToUpper()
        }).ToList();

        builder.HasData(roles);
    }
}