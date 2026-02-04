namespace Logica.UILayerPanel;

internal class TableColumnBuilder : IColumnBuilder
{
    private readonly TableColumn _column;
    private readonly TableRowBuilder _parent;

    public TableColumnBuilder(ColumnStyle style, TableRowBuilder? parent = null, TableColumn? column = null)
    {
        _column = column ?? new TableColumn(style);
        _parent = parent;
    }

    public IRowBuilder Row(float height = 100, SizeType sizeType = SizeType.Percent)
    {
        var row = new TableRow(new RowStyle(sizeType, height));
        _column.AddChild(row);
        return new TableRowBuilder(new RowStyle(sizeType, height), this, row);
    }

    public IColumnBuilder Content(Control content)
    {
        _column.WithContent(content);
        return this;
    }

    public IRowBuilder ContentEnd(Control content)
    {
        Content(content);
        return End();
    }

    public IRowBuilder End()
    {
        return _parent ?? throw new InvalidOperationException("Cannot End root column");
    }

    public Control Build()
    {
        return _column.Compile();
    }
}