namespace Domain.Entitys.Compare;

public sealed class VisitorEntityNameSurnameRelationalComparer : IComparer<VisitorEntity>
{
    public int Compare(VisitorEntity? x, VisitorEntity? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;

        var nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        if (nameComparison != 0) return nameComparison;
        return string.Compare(x.Surname, y.Surname, StringComparison.Ordinal);
    }
}