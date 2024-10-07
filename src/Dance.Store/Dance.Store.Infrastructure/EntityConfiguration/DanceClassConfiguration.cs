using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.EntityConfiguration;

public class DanceClassConfiguration : IEntityTypeConfiguration<DanceClass>
{
    public void Configure(EntityTypeBuilder<DanceClass> builder)
    {
        builder.HasKey(dc => dc.Id);

        builder.Property(dc => dc.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(dc => dc.ClassDuration)
            .IsRequired();

        builder.Property(dc => dc.Price)
            .IsRequired();

        builder.Property(dc => dc.NumberOfPlaces)
            .IsRequired();

        builder.Property(dc => dc.Description)
            .HasMaxLength(512);

        builder.Property(dc => dc.Date)
            .IsRequired();

        builder.HasOne(dc => dc.Trainer)
            .WithMany(t => t.DanceClasses)
            .HasForeignKey(dc => dc.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}