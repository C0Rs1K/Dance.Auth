using System.Linq.Expressions;
using Dance.Store.Domain.Interfaces;
using Dance.Store.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Dance.Store.Infrastructure.Repositories;

public abstract class BaseRepository<T>(DanceDbContext context) : IBaseRepository<T>
    where T : class
{
    public virtual void Create(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public virtual void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public virtual IQueryable<T> GetRange(Expression<Func<T, bool>> condition,
        CancellationToken cancellationToken)
    {
        return context.Set<T>().Where(condition)
            .AsNoTracking();
    }

    public virtual async Task<T?> GetFirstAsync(Expression<Func<T, bool>> condition,
        CancellationToken cancellationToken)
    {
        return await context.Set<T>().Where(condition)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public virtual void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }
}