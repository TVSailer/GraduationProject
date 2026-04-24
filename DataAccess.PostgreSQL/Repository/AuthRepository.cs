using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class AuthRepository(ApplicationDbContext DbContext) : RepositoryModel<AuthEntity>(DbContext)
{
    protected override IQueryable<AuthEntity> SettingDbSet(DbSet<AuthEntity> dbSet)
        => dbSet
            .Include(e => e.UserRole);
}