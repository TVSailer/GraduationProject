using System.Windows.Forms;

namespace UserInterface.LayoutPanel;

public class BuilderLayoutPanel
{
    public IColumnBuilder Column(float width = 100, SizeType sizeType = SizeType.Percent)
    {
        return new TableColumnBuilder(new ColumnStyle(sizeType, width));
    }

    public IRowBuilder Row(float height = 100, SizeType sizeType = SizeType.Percent)
    {
        return new TableRowBuilder(new RowStyle(sizeType, height));
    }
}
