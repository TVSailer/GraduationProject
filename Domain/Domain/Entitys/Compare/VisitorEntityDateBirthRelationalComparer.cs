namespace Domain.Entitys.Compare;

public sealed class VisitorEntityDateBirthRelationalComparer : IComparer<VisitorEntity>
{
    public int Compare(VisitorEntity? x, VisitorEntity? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;

        var dateX = x.GetDateBirth();
        var dateY = y.GetDateBirth();

        if (dateX == dateY) return 0;
        if (dateX > dateY) return 1;
        if (dateX < dateY) return -1;

        return string.Compare(x.DateBirth, y.DateBirth, StringComparison.Ordinal);
    }
}