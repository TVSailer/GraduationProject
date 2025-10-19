namespace Logica
{
    public static partial class TableLayoutPanelExtension
    {
        public static TableLayoutPanel ControlsAddByColumnOrRow<T>(
            this TableLayoutPanel table, List<T> controls, int column, int row, bool byColumn) 
            where T : Control
        {
            foreach (var control in controls)
            {
                if (byColumn)
                {
                    table.ControlsAdd(control, column, row);
                    column++;
                }
                else
                {
                    table.ControlsAdd(control, column, row);
                    row++;
                }
            }

            return table;
        }

        public static TableLayoutPanel ControlsAdd(
            this TableLayoutPanel table, Control control, int column, int row) 
        {
            table.Controls.Add(control, column, row);
            return table;
        }

        public static TableLayoutPanel ControlsAdd(
           this TableLayoutPanel table, Control control, int column, int row, int valueColumnSpan, int valueRowSpan)
        {
            table.Controls.Add(control, column, row);
            if (valueColumnSpan > 1) table.SetColumnSpan(control, valueColumnSpan);
            if (valueRowSpan > 1) table.SetRowSpan(control, valueRowSpan);

            return table;
        }
        
        public static TableLayoutPanel ControlAddIsRowsAbsolute(
           this TableLayoutPanel table, Control control, int heinght)
        {
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, heinght));
            table.Controls.Add(control, 0, table.RowStyles.Count -1);

            return table;
        }
        
        public static TableLayoutPanel ControlAddIsColumnAbsolute(
           this TableLayoutPanel table, Control control, int weidht)
        {
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, weidht));
            table.Controls.Add(control, table.ColumnStyles.Count-1, 0);

            return table;
        }

        public static TableLayoutPanel AddingColumnsStyles(this TableLayoutPanel table, params ColumnStyle[] columnStyles)
        {
            if (columnStyles == null)
            {
                table.ColumnCount = 1;
                return table;
            }

            foreach (var columnStyle in columnStyles)
                table.ColumnStyles.Add(columnStyle);

            return table;
        }
        

        public static TableLayoutPanel AddingRowsStyles(this TableLayoutPanel table, params RowStyle[] rowStyles)
        {
            if (rowStyles == null)
            {
                table.RowCount = 1;
                return table;
            }

            foreach (var rowStyle in rowStyles)
                table.RowStyles.Add(rowStyle);

            return table;
        }
    }
}

