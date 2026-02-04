
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

        if (this is TableColumn column)
        {
            table.ColumnCount = 1;
            table.RowCount = Children.Count;
            var style = (ColumnStyle)Style;
            table.ColumnStyles.Add(new ColumnStyle(style.SizeType, style.Width));

            for (int i = 0; i < Children.Count; i++)
            {
                var child = Children[i];
                if (child.Style is RowStyle rowStyle)
                {
                    table.RowStyles.Add(rowStyle);
                }
                table.Controls.Add(child.Compile(), 0, i);
            }
        }
        else if (this is TableRow row)
        {
            table.ColumnCount = Children.Count;
            table.RowCount = 1;
            var style = (RowStyle)Style;
            table.RowStyles.Add(new RowStyle(style.SizeType, style.Height));

            for (int i = 0; i < Children.Count; i++)
            {
                var child = Children[i];
                if (child.Style is ColumnStyle columnStyle)
                {
                    table.ColumnStyles.Add(columnStyle);
                }
                table.Controls.Add(child.Compile(), i, 0);
            }
        }

        return table;
    }
}