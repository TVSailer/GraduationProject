using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class VisitorRepository(ApplicationDbContext DbContext) : RepositoryModel<VisitorEntity>(DbContext)
{
    protected override IQueryable<VisitorEntity> SettingDbSet(DbSet<VisitorEntity> dbSet)
        => dbSet
            .Include(e => e.Lessons)
            .Include(e => e.Reviews)
            .Include(e => e.AuthEntity)
            .Include(e => e.DateAttendances);
}