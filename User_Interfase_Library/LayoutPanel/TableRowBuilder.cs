using System.Windows.Forms;
using User_Interface_Library.LayerPanel;
using User_Interface_Library.TableLayerPanel;
using User_Interface_Library.TableLayerPanel.ContentSelection;

namespace User_Interface_Library.LayoutPanel;

internal class TableRowBuilder : IRowBuilder
{
    private readonly TableRow _row;
    private readonly TableColumnBuilder? _parentColumn;

    public TableRowBuilder(RowStyle style, TableColumnBuilder? parentColumn = null, TableRow? row = null)
    {
        _row = row ?? new TableRow(style);
        _parentColumn = parentColumn;
    }

    public IContentSelector<IColumnBuilder> Content()
    {
        return new ContentSelector<IColumnBuilder>(_parentColumn, content => _row.WithContent(content));
    }

    public IColumnBuilder Column(float width = 100, SizeType sizeType = SizeType.Percent)
    {
        var column = new TableColumn(new ColumnStyle(sizeType, width));
        _row.AddChild(column);
        return new TableColumnBuilder(new ColumnStyle(sizeType, width), this, column);
    }

    public IColumnBuilder ContentEnd(Control content)
    {
        _row.WithContent(content);
        return End();
    }

    public IColumnBuilder End()
    {
        if (_parentColumn != null)
            return _parentColumn;

        throw new InvalidOperationException("No parent column to return to");
    }

    public Control Build()
    {
        return _row.Compile();
    }
}