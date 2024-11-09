using System.Reflection;
using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.Context;

public class DanceDbContext(DbContextOptions<DanceDbContext> options) : DbContext(options)
{
    public DbSet<DanceClass> DanceClasses { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<RegistrationStatusEnt> RegistrationStatuses { get; set; }
    public DbSet<StudentRegistration> StudentRegistrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}