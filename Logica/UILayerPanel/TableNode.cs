
using System.Windows.Forms;

namespace Logica.UILayerPanel;

public abstract class TableNode
{
    protected readonly List<TableNode> Children = new();
    protected Control? Content;
    protected readonly TableLayoutStyle Style;

    protected TableNode(TableLayoutStyle style)
    {
        Style = style;
    }

    public void AddChild(TableNode child) => Children.Add(child);
    public void WithContent(Control content) => Content = content;

    public Control Compile()
    {
        if (Content != null)
            return Content;

        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill
        };

        if (Style is ColumnStyle column)
        {
            table.ColumnCount = 1;
            table.RowCount = Children.Count;
            table.ColumnStyles.Add(new ColumnStyle(column.SizeType, column.Width));

            for (int i = 0; i < Children.Count; i++)
            {
                var child = Children[i];
                if (child.Style is not RowStyle rowStyle) continue;

                var control = child.Compile();
                table.RowStyles.Add(rowStyle.SizeType == SizeType.AutoSize ? new RowStyle(SizeType.Absolute, control.PreferredSize.Height) : rowStyle);
                table.Controls.Add(control, 0, i);
            }
        }
        else if (Style is RowStyle row)
        {
            table.ColumnCount = Children.Count;
            table.RowCount = 1;
            table.RowStyles.Add(new RowStyle(row.SizeType, row.Height));

            for (int i = 0; i < Children.Count; i++)
            {
                var child = Children[i];
                if (child.Style is not ColumnStyle columnStyle) continue;

                var control = child.Compile();
                table.ColumnStyles.Add(columnStyle.SizeType == SizeType.AutoSize ? new ColumnStyle(SizeType.Absolute, control.PreferredSize.Width) : columnStyle);
                table.Controls.Add(control, i, 0);
            }
        }

        return table;
    }
}