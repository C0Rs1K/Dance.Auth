using Dance.Subscription.Domain.Entities;
using Dance.Subscription.Domain.Interfaces;
using MongoDB.Driver;

namespace Dance.Subscription.infrastructure.Repositories;

public class StudentRepository(IMongoDatabase database) : BaseRepository<Student>(database), IStudentRepository
{
    protected override string CollectionName => "Students";
}
