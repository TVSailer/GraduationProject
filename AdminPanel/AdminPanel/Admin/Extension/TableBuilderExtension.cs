using Logica.UILayerPanel;

public static class TableBuilderExtension
{
    public static IRowBuilder RowAutoSize(this IColumnBuilder columnBuilder) => columnBuilder.Row(0, SizeType.AutoSize);
    public static IColumnBuilder ColumnAutoSize(this IRowBuilder rowBuilder) => rowBuilder.Column(0, SizeType.AutoSize);
}