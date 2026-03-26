using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class LessonRepository(ApplicationDbContext DbContext) : RepositoryModel<LessonEntity>(DbContext)
{
    protected override IQueryable<LessonEntity> SettingDbSet(DbSet<LessonEntity> dbSet)
        => dbSet
            .Include(e => e.Visitors)
            .Include(e => e.Reviews)
            .Include(e => e.AttendanceDates)
            .Include(e => e.Category)
            .Include(e => e.Schedule)
            .Include(e => e.Images);
}