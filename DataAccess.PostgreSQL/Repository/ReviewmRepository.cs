using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class ReviewmRepository(ApplicationDbContext DbContext) : RepositoryModel<ReviewEntity>(DbContext)
{
    protected override IQueryable<ReviewEntity> SettingDbSet(DbSet<ReviewEntity> dbSet)
        => dbSet
            .Include(e => e.Lesson)
            .Include(e => e.Rating)
            .Include(e => e.Visitor);
}