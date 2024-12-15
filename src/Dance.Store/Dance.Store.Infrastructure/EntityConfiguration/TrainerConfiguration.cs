using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.EntityConfiguration;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasKey(t => t.Id);;

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(t => t.Phone)
            .IsRequired()
            .HasMaxLength(16);

        builder.HasMany(t => t.DanceClasses)
            .WithOne(dc => dc.Trainer)
            .HasForeignKey(dc => dc.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}