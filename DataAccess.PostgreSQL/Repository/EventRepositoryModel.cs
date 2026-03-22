using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class EventRepositoryModel(ApplicationDbContext DbContext) : RepositoryModel<EventEntity>(DbContext)
{
    protected override IQueryable<EventEntity> SettingDbSet(DbSet<EventEntity> dbSet)
        => dbSet
            .Include(e => e.Images)
            .Include(e => e.Category);
}