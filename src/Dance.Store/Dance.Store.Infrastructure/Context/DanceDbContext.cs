using System.Reflection;
using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.Context;

public class DanceDbContext(DbContextOptions<DanceDbContext> options) : DbContext(options)
{
    public DbSet<DanceClassEntity> DanceClasses { get; set; }
    public DbSet<TrainerEntity> Trainers { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<RegistrationStatusEntity> RegistrationStatuses { get; set; }
    public DbSet<StudentRegistrationEntity> StudentRegistrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}