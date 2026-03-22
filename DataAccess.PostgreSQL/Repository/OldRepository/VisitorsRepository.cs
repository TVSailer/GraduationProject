using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.ModelsPrimitive;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

public class VisitorsRepository(ApplicationDbContext dbContext) : Repository<VisitorEntity>(dbContext: dbContext)
{
    public override List<VisitorEntity> Get()
    {
        return DbContext.Visitors
            .Include(navigationPropertyPath: v => v.Lessons)
            .Include(navigationPropertyPath: v => v.Dates)
            .Include(navigationPropertyPath: v => v.Reviews)
            .Include(navigationPropertyPath: v => v.AuthEntity)
            .ToList() ?? throw new ArgumentNullException();
    }

    public override void Update(long id, VisitorEntity visitor)
        => DbContext.Visitors
            .Where(predicate: v => v.Id == id)
            .ExecuteUpdate(setPropertyCalls: v => v
                .SetProperty(v => v.FIO, visitor.FIO)
                .SetProperty(v => v.DateBirth, visitor.DateBirth)
                .SetProperty(v => v.NumberPhone, visitor.NumberPhone));

    public override void Delete(long idEntity)
    {
        DbContext.Remove(entity: DbContext.Visitors.Single(predicate: v => v.Id == idEntity));
        DbContext.SaveChanges();
    }
}