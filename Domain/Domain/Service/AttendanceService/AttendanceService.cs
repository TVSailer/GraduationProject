using Domain.Entitys;
using Domain.Repository;
using Domain.Service.AttendanceService.BaseAttendanceService;

namespace Domain.Service.AttendanceService;

public class AttendanceService(IRepository<VisitorEntity> repositoryV, IRepository<DateAttendanceEntity> repositoryD) : IAttendanceService
{
    public IEnumerable<string[]> GetVisitorWithAttendance(LessonEntity lesson)
    {
        var lessonDates = lesson.AttendanceDates
            .OrderBy(d => d.ToDateTime())
            .ToArray();

        var allDates = repositoryD
            .Get()
            .AsEnumerable()
            .Where(d => d.Lesson.Id == lesson.Id)
            .ToDictionary(d => d.Date);

        var attendanceByDate = lessonDates
            .Select(lessonDate => allDates.TryGetValue(lessonDate.Date, out var date)
                ? date.Visitors.Select(v => v.Id).ToHashSet()
                : new HashSet<long>())
            .ToArray();

        var visitors = repositoryV
            .Get()
            .AsEnumerable()
            .Where(v => lesson.Visitors.Contains(v));

        foreach (var visitor in visitors)
        {
            var result = new string[1 + lessonDates.Length];
            result[0] = visitor.ToString();

            for (int i = 0; i < lessonDates.Length; i++)
                result[i + 1] = attendanceByDate[i].Contains(visitor.Id) ? "нб" : "";

            yield return result;
        }
    }
}