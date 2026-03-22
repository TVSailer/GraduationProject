public static class ListExtension
{
    public static string ParseSchedule(this IEnumerable<string> list)
    {
        return
            ""; //list.Aggregate<LessonScheduleEntity?, string>(null!, (current, s) => current + $"{s?.Day.ToDescriptionString()[..4]}. {s!.Start}-{s.End} ");
    }
}