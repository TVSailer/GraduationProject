using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository;

public class AuthRepository(ApplicationDbContext dbContext) : Repository<AuthEntity>(dbContext)
{
    public override List<AuthEntity> Get()
    {
        return DbContext.Auths.ToList() ?? throw new NullReferenceException();
    }

    public override void Update(long id, AuthEntity entity)
    {
        DbContext.Auths
            .Where(predicate: v => v.Id == id)
            .ExecuteUpdate(setPropertyCalls: v => v
                .SetProperty(v => v.Login, entity.Login)
                .SetProperty(v => v.Password, entity.Password));

        DbContext.SaveChanges();
    }

    public override void Delete(long idEntity)
    {
        throw new NotImplementedException();
    }
}