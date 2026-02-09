using System.ComponentModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica.UILayerPanel;

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

public static class TableBuilderExtension
{
    public static IRowBuilder RowAutoSize(this IColumnBuilder columnBuilder) => columnBuilder.Row(0, SizeType.AutoSize);
    public static IColumnBuilder ColumnAutoSize(this IRowBuilder rowBuilder) => rowBuilder.Column(0, SizeType.AutoSize);
}
