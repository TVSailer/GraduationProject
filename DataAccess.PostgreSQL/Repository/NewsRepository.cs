using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class NewsRepository(ApplicationDbContext DbContext) : RepositoryModel<NewsEntity>(DbContext)
{
    protected override IQueryable<NewsEntity> SettingDbSet(DbSet<NewsEntity> dbSet)
        => dbSet
            .Include(e => e.Images)
            .Include(e => e.Category);
}