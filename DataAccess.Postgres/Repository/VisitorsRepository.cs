using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{

    public class VisitorsRepository : Repository<VisitorEntity>
    {
        public VisitorsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override List<VisitorEntity> Get()
            => DbContext.Visitors
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        //public bool VerifyVisitor(string login, string password)
        //{
        //    Visitor = DbContext.Visitors
        //    .AsNoTracking()
        //    .FirstOrDefault(v => v.Login == login && v.Password == password);

        //    return Visitor != null;
        //}

        //public List<VisitorEntity> Get(string name, string surname, string patronymic)
        //    => DbContext.Visitors
        //    .AsNoTracking()
        //    .Where(v => v.Name.StartsWith(name))
        //    .Where(v => v.Surname.StartsWith(surname))
        //    .Where(v => v.Patronymic.StartsWith(patronymic))
        //    .ToList() ?? throw new ArgumentNullException();

        public List<VisitorEntity>? GetVisitorsLesson(int idLesson)
            => DbContext.Visitors
            .Include(v => v.Lessons)
            .AsNoTracking()
            .Where(v => v.Lessons.Where(l => l.Id == idLesson) != null)
            .ToList();
        
        public List<VisitorEntity> Get(int id)
            => DbContext.Visitors
            .AsNoTracking()
            .Where(v => v.Id == id)
            .ToList() ?? throw new ArgumentNullException();

        public override void Update(long id, VisitorEntity visitor)
            => DbContext.Visitors
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.FIO, visitor.FIO)
                    //.SetProperty(v => v.Surname, visitor.Surname)
                    //.SetProperty(v => v.Patronymic, visitor.Patronymic)
                    .SetProperty(v => v.DateBirth, visitor.DateBirth)
                    .SetProperty(v => v.NumberPhone, visitor.NumberPhone)
                    .SetProperty(v => v.Login, visitor.Login)
                    .SetProperty(v => v.Password, visitor.Password));

        public override void Delete(VisitorEntity entity)
            => DbContext.Visitors
            .Where(v => v.Id == entity.Id)
            .ExecuteDelete();

    }
}
