using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository;

public class MementoLesson(ApplicationDbContext DbContext, Repository<DateAttendanceEntity> repositoryD)
{
    public LessonEntity? Lesson { get; set; }
    public bool IsAdd => Lesson is not null && Lesson.MaxParticipants > Lesson.Visitors.Count;

    public List<VisitorEntity> GetVisitorsNotBelongingLesson()
    {
        if (Lesson is null) throw new ArgumentNullException();

        return DbContext.Visitors
            .Include(navigationPropertyPath: v => v.Lessons)
            .Where(predicate: v => !Lesson.Visitors.Contains(v))
            .ToList() ?? throw new ArgumentNullException();
    }

    public List<VisitorEntity> GetVisitorsBelongingLesson()
    {
        return Lesson is null ? throw new ArgumentNullException() : Lesson.Visitors;
    }
    public List<ReviewEntity> GetReviews()
    {
        return Lesson is null ? throw new ArgumentNullException() : Lesson.Reviews;
    }
    public List<DateAttendanceEntity> GetDateAttendance()
    {
        return Lesson is null ? throw new ArgumentNullException() : repositoryD.Get().Where(predicate: d => d.Lesson.Id == Lesson.Id).ToList();
    }

    public void AddVisitor(VisitorEntity obj)
    {
        if (Lesson is null) throw new ArgumentNullException();
        if (Lesson.MaxParticipants <= Lesson.Visitors.Count) throw new ArgumentOutOfRangeException();


        Lesson.Visitors.Add(item: obj);
        DbContext.SaveChanges();
    }
    
    public void AddDateAttendance(DateAttendanceEntity obj)
    {
        if (Lesson is null) throw new ArgumentNullException();

        obj.LessonId = Lesson.Id;
        repositoryD.Add(obj: obj);
    }

    public void DeleteVisitor(long idEntity)
    {
        if (Lesson is null) throw new ArgumentNullException();
        Lesson.Visitors.RemoveAll(match: v => v.Id == idEntity);
        DbContext.SaveChanges();
    }
}