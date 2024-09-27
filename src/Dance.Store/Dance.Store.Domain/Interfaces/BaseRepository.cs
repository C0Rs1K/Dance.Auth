using System.Linq.Expressions;

namespace Dance.Store.Domain.Interfaces;

public interface IBaseRepository<T>
{
    public Task<T?> GetFirstAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken);
    public IQueryable<T> GetRange(Expression<Func<T, bool>> condition, CancellationToken cancellationToken);
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}