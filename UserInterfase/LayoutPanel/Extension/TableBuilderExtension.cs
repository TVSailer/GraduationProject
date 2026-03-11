using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel;


public static class TableBuilderExtension
{
    public static IRowBuilder RowAutoSize(this IColumnBuilder columnBuilder) => columnBuilder.Row(0, SizeType.AutoSize);
    public static IRowBuilder RowAbsolute(this IColumnBuilder columnBuilder, int size) => columnBuilder.Row(size, SizeType.Absolute);
    public static IColumnBuilder ColumnAutoSize(this IRowBuilder rowBuilder) => rowBuilder.Column(0, SizeType.AutoSize);
    public static IColumnBuilder ColumnAbsolute(this IRowBuilder rowBuilder, int size) => rowBuilder.Column(size, SizeType.Absolute);
}

