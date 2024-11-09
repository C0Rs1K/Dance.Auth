using System.Linq.Expressions;

namespace Dance.Subscription.Domain.Interfaces;

public interface IBaseRepository<T>
{
    public Task<T?> GetFirstAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken);
    public Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken);
    public Task CreateAsync(T entity, CancellationToken cancellationToken);
    public Task UpdateAsync(string id, T entity, CancellationToken cancellationToken);
    public Task DeleteAsync(string id, CancellationToken cancellationToken);
}