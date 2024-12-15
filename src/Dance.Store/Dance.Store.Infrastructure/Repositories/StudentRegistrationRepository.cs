using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using Dance.Store.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Dance.Store.Infrastructure.Repositories;

public class StudentRegistrationRepository(DanceDbContext context) : BaseRepository<StudentRegistration>(context), IStudentRegistrationRepository
{
    public override async Task<StudentRegistration?> GetFirstAsync(Expression<Func<StudentRegistration, bool>> condition, CancellationToken cancellationToken)
    {
        return await context.Set<StudentRegistration>()
            .Where(condition)
            .AsNoTracking()
            .Include(x => x.Class)
            .Include(x => x.Student)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public override async Task<IEnumerable<StudentRegistration>> GetRangeAsync(Expression<Func<StudentRegistration, bool>> condition, CancellationToken cancellationToken)
    {
        return await context.Set<StudentRegistration>()
            .Where(condition)
            .AsNoTracking()
            .Include(x => x.Class)
            .Include(x => x.Student)
            .Include(x => x.Status)
            .ToListAsync(cancellationToken);
    }
}