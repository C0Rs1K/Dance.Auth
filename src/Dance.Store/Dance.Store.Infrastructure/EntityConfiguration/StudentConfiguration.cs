using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.EntityConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(s => s.Instagram)
            .HasMaxLength(64);

        builder.Property(s => s.Phone)
            .IsRequired()
            .HasMaxLength(16);
    }
}