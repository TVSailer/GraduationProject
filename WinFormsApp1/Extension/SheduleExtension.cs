using System.ComponentModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;

public static class ListExtension
{
    public static string ParseSchedule(this IEnumerable<LessonScheduleEntity> list)
    {
        string value = null;
        foreach (var s in list)
            value += $"{s.Day.ToDescriptionString().Substring(0, 4)}. {s.Start}-{s.End} ";

        return value;
    }
}
