using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class VisitorsRepository(ApplicationDbContext dbContext) : Repository<VisitorEntity>(dbContext)
    {
        public override List<VisitorEntity> Get()
            => DbContext.Visitors
            .ToList() ?? throw new ArgumentNullException();

        public List<VisitorEntity> Get(int id)
            => DbContext.Visitors
            .Where(v => v.Id == id)
            .ToList() ?? throw new ArgumentNullException();

        public override void Update(long id, VisitorEntity visitor)
            => DbContext.Visitors
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.FIO, visitor.FIO)
                    .SetProperty(v => v.DateBirth, visitor.DateBirth)
                    .SetProperty(v => v.NumberPhone, visitor.NumberPhone)
                    .SetProperty(v => v.Login, visitor.Login)
                    .SetProperty(v => v.Password, visitor.Password));

        public override void Delete(long idEntity)
        {
            DbContext.Visitors
                .Where(v => v.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
