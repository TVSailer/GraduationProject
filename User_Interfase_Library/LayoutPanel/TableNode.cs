
using System.Windows.Forms;

namespace User_Interface_Library.LayoutPanel;

public abstract class TableNode(TableLayoutStyle style)
{
    protected readonly List<TableNode> Children = [];
    protected Control? Content;
    protected readonly TableLayoutStyle Style = style;

    public void AddChild(TableNode child) => Children.Add(child);
    public void WithContent(Control content) => Content = content;

    public Control Compile()
    {
        if (Content != null)
            return Content;

        var layerPanel = new TableLayoutPanel() { Dock = DockStyle.Fill };

        if (Style is ColumnStyle column)
        {
            layerPanel.ColumnCount = 1;
            layerPanel.RowCount = Children.Count;
            layerPanel.ColumnStyles.Add(new ColumnStyle(column.SizeType, column.Width));

            for (int i = 0; i < Children.Count; i++)
            {
                var child = Children[i];
                if (child.Style is not RowStyle rowStyle) continue;

                var control = child.Compile();
                layerPanel.RowStyles.Add(rowStyle.SizeType == SizeType.AutoSize ? new RowStyle(SizeType.Absolute, control.PreferredSize.Height) : rowStyle);
                layerPanel.Controls.Add(control, 0, i);
            }
        }
        else if (Style is RowStyle row)
        {
            layerPanel.ColumnCount = Children.Count;
            layerPanel.RowCount = 1;
            layerPanel.RowStyles.Add(new RowStyle(row.SizeType, row.Height));

            for (int i = 0; i < Children.Count; i++)
            {
                var child = Children[i];
                if (child.Style is not ColumnStyle columnStyle) continue;

                var control = child.Compile();
                layerPanel.ColumnStyles.Add(columnStyle.SizeType == SizeType.AutoSize ? new ColumnStyle(SizeType.Absolute, control.PreferredSize.Width) : columnStyle);
                layerPanel.Controls.Add(control, i, 0);
            }
        }

        return layerPanel;
    }
}