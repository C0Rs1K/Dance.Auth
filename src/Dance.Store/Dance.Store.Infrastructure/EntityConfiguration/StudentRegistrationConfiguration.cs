using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.EntityConfiguration;

public class StudentRegistrationConfiguration : IEntityTypeConfiguration<StudentRegistration>
{
    public void Configure(EntityTypeBuilder<StudentRegistration> builder)
    {
        builder.HasKey(sr => sr.Id);

        builder.Property(sr => sr.StudentId)
            .IsRequired();

        builder.Property(sr => sr.ClassId)
            .IsRequired();

        builder.Property(sr => sr.StatusId)
            .IsRequired();

        builder.HasOne(sr => sr.Student)
            .WithMany()
            .HasForeignKey(sr => sr.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sr => sr.Class)
            .WithMany()
            .HasForeignKey(sr => sr.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sr => sr.Status)
            .WithMany()
            .HasForeignKey(sr => sr.StatusId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}