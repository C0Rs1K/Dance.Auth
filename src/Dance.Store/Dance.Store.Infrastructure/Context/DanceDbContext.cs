using Dance.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.Context;

public class DanceDbContext : DbContext
{
    public DbSet<DanceClassEntity> Type { get; set; }
}