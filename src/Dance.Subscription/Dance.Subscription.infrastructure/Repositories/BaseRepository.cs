using System.Collections;
using System.Linq.Expressions;
using Dance.Subscription.Domain.Entities;
using Dance.Subscription.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dance.Subscription.infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{
    protected abstract string CollectionName { get; }

    private readonly IMongoCollection<T> _collection;

    protected BaseRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<T>(CollectionName);
    }

    public virtual async Task<T?> GetFirstAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Where(condition);

        return await _collection.Find(filter)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Where(condition);

        return await _collection.Find(filter)
            .ToListAsync(cancellationToken); 
    }

    public virtual async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(entity, null, cancellationToken);
    }

    public virtual async Task UpdateAsync(string id, T entity, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", new ObjectId(id)), entity, cancellationToken: cancellationToken);
    }

    public virtual async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", new ObjectId(id)), cancellationToken);
    }
}