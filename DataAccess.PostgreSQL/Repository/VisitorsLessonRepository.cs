using DataAccess.PostgreSQL.Logger;
using DataAccess.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using ILogger = DataAccess.PostgreSQL.Logger.ILogger;

namespace DataAccess.PostgreSQL.Repository;

public class MementoLesson(
    ApplicationDbContext DbContext, 
    Repository<DateAttendanceEntity> repositoryD,
    AuthRepository repositoryAuth)
{
    public LessonEntity? Lesson { get; set; }
    public bool IsAddVisitor => Lesson is not null && Lesson.MaxParticipants > Lesson.Visitors.Count;

    public bool TryAddLesson(out ILogger logger)
    {
        if (!DbContext.Teachers.Any())
        {
            logger = new RepositoryLogger("Добавьте преподователя!");
            return false;
        }
        if (!DbContext.Category.Any())
        {
            logger = new RepositoryLogger("Добавьте категорию!");
            return false;
        }

        logger = new EmptyLogger();
        return true;
    }

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

    public void AddNewVisitor(VisitorEntity obj, out ILogger logger)
    {
        if (Lesson is null) throw new ArgumentNullException();
        if (Lesson.MaxParticipants <= Lesson.Visitors.Count) throw new ArgumentOutOfRangeException();

        obj.AuthEntity = repositoryAuth.AddAuthUser(obj.FIO, out logger);

        Lesson.Visitors.Add(item: obj);
        DbContext.SaveChanges();
    }
    
    public void AddOldVisitor(VisitorEntity obj)
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
    
    public void DeleteReview(long idEntity)
    {
        if (Lesson is null) throw new ArgumentNullException();
        Lesson.Reviews.RemoveAll(match: v => v.Id == idEntity);
        DbContext.SaveChanges();
    }
}