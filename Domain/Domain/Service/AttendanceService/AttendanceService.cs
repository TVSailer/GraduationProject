using Domain.Entitys;
using Domain.Repository;
using Domain.Service.AttendanceService.BaseAttendanceService;

namespace Domain.Service.AttendanceService;

public class AttendanceService(IRepository<VisitorEntity> repositoryV, IRepository<DateAttendanceEntity> repositoryD) : IAttendanceService
{
    public IEnumerable<string[]> GetVisitorWithAttendance(LessonEntity lesson)
    {
        var attendanceByDate = repositoryD
            .Get()
            .AsEnumerable()
            .Where(d => lesson.AttendanceDates
                .Contains(d))
            .Select(date => date.Visitors.Select(v => v.Id).ToHashSet())
            .ToArray();

        foreach (var visitor in repositoryV
                     .Get()
                     .AsEnumerable()
                     .Where(v => lesson.Visitors.Contains(v)))
            yield return Enumerable.Range(0, attendanceByDate.Length + 1)
                .Select(i => i == 0
                    ? visitor.ToString()
                    : attendanceByDate[i - 1].Contains(visitor.Id) ? "нб" : "")
                .ToArray();
    }
}