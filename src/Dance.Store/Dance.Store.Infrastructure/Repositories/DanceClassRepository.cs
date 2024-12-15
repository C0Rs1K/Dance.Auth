using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using Dance.Store.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Dance.Store.Infrastructure.Repositories;

public class DanceClassRepository(DanceDbContext context) : BaseRepository<DanceClass>(context), IDanceClassRepository
{
    public override async Task<IEnumerable<DanceClass>> GetRangeAsync(Expression<Func<DanceClass, bool>> condition, CancellationToken cancellationToken)
    {
        return await context.Set<DanceClass>().Where(condition)
            .AsNoTracking()
            .Include(x => x.Trainer)
            .ToListAsync(cancellationToken);
    }

    public override async Task<DanceClass?> GetFirstAsync(Expression<Func<DanceClass, bool>> condition, CancellationToken cancellationToken)
    {
        return await context.Set<DanceClass>().Where(condition)
            .AsNoTracking()
            .Include(x => x.Trainer)
            .FirstOrDefaultAsync(cancellationToken);
    }
}