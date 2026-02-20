using System.ComponentModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;

public static class ListExtension
{
    public static string ParseSchedule(this IEnumerable<LessonScheduleEntity> list)
    {
        return list.Aggregate<LessonScheduleEntity?, string>(null!, (current, s) => current + $"{s?.Day.ToDescriptionString()[..4]}. {s!.Start}-{s.End} ");
    }
}