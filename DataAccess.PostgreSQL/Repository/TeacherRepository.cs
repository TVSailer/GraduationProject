using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class TeacherRepository(ApplicationDbContext DbContext) : RepositoryModel<TeacherEntity>(DbContext)
{
    protected override IQueryable<TeacherEntity> SettingDbSet(DbSet<TeacherEntity> dbSet)
        => dbSet
            .Include(e => e.Lessons)
            .Include(e => e.AuthEntity);
}