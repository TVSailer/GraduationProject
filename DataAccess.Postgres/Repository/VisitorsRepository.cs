using System.Diagnostics;
using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository;

public class VisitorsRepository(ApplicationDbContext dbContext) : Repository<VisitorEntity>(dbContext: dbContext)
{
    public override List<VisitorEntity> Get()
    {
        return DbContext.Visitors
            .Include(navigationPropertyPath: v => v.Lessons)
            .Include(navigationPropertyPath: v => v.Dates)
            .Include(navigationPropertyPath: v => v.Reviews)
            .ToList() ?? throw new ArgumentNullException();
    }

    public override void Update(long id, VisitorEntity visitor)
        => DbContext.Visitors
            .Where(predicate: v => v.Id == id)
            .ExecuteUpdate(setPropertyCalls: v => v
                .SetProperty(v => v.FIO, visitor.FIO)
                .SetProperty(v => v.DateBirth, visitor.DateBirth)
                .SetProperty(v => v.NumberPhone, visitor.NumberPhone)
                .SetProperty(v => v.Login, visitor.Login)
                .SetProperty(v => v.Password, visitor.Password));

    public override void Delete(long idEntity)
    {
        DbContext.Remove(entity: DbContext.Visitors.Single(predicate: v => v.Id == idEntity));
        DbContext.SaveChanges();
    }
}