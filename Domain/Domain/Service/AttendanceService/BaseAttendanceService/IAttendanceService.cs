using Domain.Entitys;

namespace Domain.Service.AttendanceService.BaseAttendanceService;

public interface IAttendanceService
{
    public IEnumerable<string[]> GetVisitorWithAttendance(LessonEntity lesson);
}