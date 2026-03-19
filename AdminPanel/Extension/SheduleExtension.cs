using DataAccess.PostgreSQL.Models;
using ExtensionFunc;

public static class ListExtension
{
    public static string ParseSchedule(this IEnumerable<LessonScheduleEntity> list)
    {
        return list.Aggregate<LessonScheduleEntity?, string>(null!, (current, s) => current + $"{s?.Day.ToDescriptionString()[..4]}. {s!.Start}-{s.End} ");
    }
}