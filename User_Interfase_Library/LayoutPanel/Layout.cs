using System.Windows.Forms;
using User_Interface_Library.LayoutPanel;
using User_Interface_Library.TableLayerPanel;

namespace User_Interface_Library.LayerPanel;

public static class LayoutPanel
{
    public static IColumnBuilder CreateColumn(float width = 100, SizeType sizeType = SizeType.Percent)
    {
        return new TableColumnBuilder(new ColumnStyle(sizeType, width));
    }

    public static IRowBuilder CreateRow(float height = 100, SizeType sizeType = SizeType.Percent)
    {
        return new TableRowBuilder(new RowStyle(sizeType, height));
    }
}
