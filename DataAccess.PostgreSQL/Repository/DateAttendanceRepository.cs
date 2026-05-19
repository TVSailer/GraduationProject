using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class DateAttendanceRepository(ApplicationDbContext DbContext) : RepositoryModel<DateAttendanceEntity>(DbContext)
{
    protected override IQueryable<DateAttendanceEntity> SettingDbSet(DbSet<DateAttendanceEntity> dbSet)
        => dbSet
            .Include(d => d.Visitors);
}