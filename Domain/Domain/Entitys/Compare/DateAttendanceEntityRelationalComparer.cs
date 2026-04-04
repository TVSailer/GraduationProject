namespace Domain.Entitys.Compare;

public sealed class DateAttendanceEntityRelationalComparer : IComparer<DateAttendanceEntity>
{
    public int Compare(DateAttendanceEntity? x, DateAttendanceEntity? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;

        var dateX = x.ToDateTime();
        var dateY = y.ToDateTime();

        if (dateX == dateY) return 0;
        if (dateX > dateY) return 1;
        if (dateX < dateY) return -1;

        return 0;
    }
}