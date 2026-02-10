using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class VisitorsRepository(ApplicationDbContext dbContext) : Repository<VisitorEntity>(dbContext)
    {
        public LessonEntity? Lesson { get; set; }
        public bool IsAdd => Lesson is not null && Lesson.MaxParticipants > Lesson.Visitors.Count;

        public override List<VisitorEntity> Get()
        {
            return Lesson is not null ? Lesson.Visitors : DbContext.Visitors
                .ToList() ?? throw new ArgumentNullException();
        }

        public bool TryAdd(VisitorEntity obj)
        {
            if (Lesson is null) return false;
            if (Lesson.MaxParticipants <= Lesson.Visitors.Count) return false;

            Add(obj);
            return true;
        }

        public override void Add(VisitorEntity obj)
        {
            if (Lesson is null) throw new ArgumentNullException();
            if (Lesson.MaxParticipants <= Lesson.Visitors.Count) throw new ArgumentOutOfRangeException();

            Lesson.Visitors.Add(obj);
            dbContext.SaveChanges();
        }

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
            Lesson?.Visitors.RemoveAll(v => v.Id == idEntity);
            DbContext.Visitors
                .Where(v => v.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
