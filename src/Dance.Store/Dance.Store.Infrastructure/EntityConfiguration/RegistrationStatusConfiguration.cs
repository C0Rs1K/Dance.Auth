using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.EntityConfiguration;

public class RegistrationStatusConfiguration : IEntityTypeConfiguration<RegistrationStatus>
{
    public void Configure(EntityTypeBuilder<RegistrationStatus> builder)
    {
        builder.HasKey(rs => rs.Id);

        builder.Property(rs => rs.Name)
            .IsRequired()
            .HasMaxLength(128);
    }
}