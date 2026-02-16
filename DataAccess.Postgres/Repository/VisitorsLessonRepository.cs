using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository;

public class VisitorsLessonRepository(Repository<VisitorEntity> repositoryV, ApplicationDbContext DbContext) : Repository<VisitorEntity>(DbContext)
{
    public LessonEntity? Lesson { get; set; }
    public bool IsAdd => Lesson is not null && Lesson.MaxParticipants > Lesson.Visitors.Count;

    public List<VisitorEntity> GetVisitorsNotBelongingLesson()
    {
        if (Lesson is null) throw new ArgumentNullException();

        return DbContext.Visitors
            .Include(v => v.Lessons)
            .Where(v => !Lesson.Visitors.Contains(v))
            .ToList() ?? throw new ArgumentNullException();
    }

    public override List<VisitorEntity> Get()
    {
        return Lesson is null ? throw new ArgumentNullException() : Lesson.Visitors;
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
        DbContext.SaveChanges();
    }

    public override void Update(long id, VisitorEntity entity)
    {
        repositoryV.Update(id, entity);
    }

    public override void Delete(long idEntity)
    {
        if (Lesson is null) throw new ArgumentNullException();
        Lesson.Visitors.RemoveAll(v => v.Id == idEntity);
        DbContext.SaveChanges();
    }
}