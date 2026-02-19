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
            .Include(v => v.Lessons)
            .Where(v => !Lesson.Visitors.Contains(v))
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
        return Lesson is null ? throw new ArgumentNullException() : repositoryD.Get().Where(d => d.Lesson.Id == Lesson.Id).ToList();
    }

    public void AddVisitor(VisitorEntity obj)
    {
        if (Lesson is null) throw new ArgumentNullException();
        if (Lesson.MaxParticipants <= Lesson.Visitors.Count) throw new ArgumentOutOfRangeException();


        Lesson.Visitors.Add(obj);
        DbContext.SaveChanges();
    }
    
    public void AddDateAttendance(DateAttendanceEntity obj)
    {
        if (Lesson is null) throw new ArgumentNullException();

        obj.LessonId = Lesson.Id;
        repositoryD.Add(obj);
    }

    public void DeleteVisitor(long idEntity)
    {
        if (Lesson is null) throw new ArgumentNullException();
        Lesson.Visitors.RemoveAll(v => v.Id == idEntity);
        DbContext.SaveChanges();
    }

    public void DeleteReview(long idEntity)
    {
        if (Lesson is null) throw new ArgumentNullException();
        Lesson.Reviews.RemoveAll(v => v.Id == idEntity);
        DbContext.SaveChanges();
    }
}