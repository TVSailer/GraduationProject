namespace Logica
{
    public static partial class TableLayoutPanelExtension
    {
        private static List<TableLayoutPanel> tables = new();

        public static TableLayoutPanel StartNewRowTableAbsolute(this TableLayoutPanel table, int size)
        {
            var newTable = FactoryElements.TableLayoutPanel();
            table.ControlAddIsRow(newTable, size, SizeType.Absolute);
            tables.Add(table);
            return newTable;
        }
        
        public static TableLayoutPanel StartNewRowTableAbsolute(this TableLayoutPanel table)
        {
            var newTable = FactoryElements.TableLayoutPanel();
            table.ControlAddIsRow(newTable, table.PreferredSize.Width, SizeType.Absolute);
            tables.Add(table);
            return newTable;
        }

        public static TableLayoutPanel EndTabel(this TableLayoutPanel table)
        {
            var oldTable = tables.Last();
            tables.Remove(oldTable);
            return oldTable;
        }


        public static TableLayoutPanel ControlAddIsRow(
           this TableLayoutPanel table, Control? control, int heinght, SizeType sizeType)
            => control == null ?
                table
                    .ControlAddIsRow(new Panel(), heinght, sizeType) :
                table
                    .AddingRowsStyles(new RowStyle(sizeType, heinght))
                    .AddControlRow(control);

        public static TableLayoutPanel ControlAddIsColumn(
           this TableLayoutPanel table, Control? control, int weidht, SizeType sizeType)
            => control == null ?
                table
                    .ControlAddIsColumn(new Panel(), weidht, sizeType) :
                table
                    .AddingColumnsStyles(new ColumnStyle(sizeType, weidht))
                    .AddControlColumn(control);

        private static TableLayoutPanel AddControlRow(this TableLayoutPanel table, Control control)
        {
            table.Controls.Add(control,
                table.ColumnStyles.Count == 0 ? 0 :
                table.ColumnStyles.Count - 1,
                table.RowStyles.Count - 1);

            return table;
        }
        
        private static TableLayoutPanel AddControlColumn(this TableLayoutPanel table, Control control)
        {
            table.Controls.Add(control,
                table.ColumnStyles.Count - 1,
                table.RowStyles.Count == 0 ? 0 :
                table.RowStyles.Count - 1);

            return table;
        }

        public static TableLayoutPanel ControlAddIsRowsAbsolute(
           this TableLayoutPanel table, Control control)
            => table.ControlAddIsRow(control, control.PreferredSize.Height, SizeType.Absolute);
        
        public static TableLayoutPanel ControlAddIsRowsAbsolute(
           this TableLayoutPanel table, Control control, int heinght)
            => table.ControlAddIsRow(control, heinght, SizeType.Absolute);

        public static TableLayoutPanel ControlAddIsRowsAbsolute(
           this TableLayoutPanel table, int heinght)
            => table.ControlAddIsRow(null, heinght, SizeType.Absolute);

        public static TableLayoutPanel ControlAddIsRowsPercent(
           this TableLayoutPanel table, Control? control)
            => table.ControlAddIsRow(control, 10, SizeType.Percent);
        
        public static TableLayoutPanel ControlAddIsRowsPercent(
           this TableLayoutPanel table, Control? control, int heingt)
            => table.ControlAddIsRow(control, heingt, SizeType.Percent);
        
        public static TableLayoutPanel ControlAddIsRowsPercent(
           this TableLayoutPanel table, int heingt)
            => table.ControlAddIsRow(null, heingt, SizeType.Percent);

        public static TableLayoutPanel ControlAddIsRowsPercent(
           this TableLayoutPanel table)
            => table.ControlAddIsRow(new Panel(), 10, SizeType.Percent);

        public static TableLayoutPanel ControlAddIsColumnAbsolute(
           this TableLayoutPanel table, Control control, int weidht)
            => table.ControlAddIsColumn(control, weidht, SizeType.Absolute);

        public static TableLayoutPanel ControlAddIsColumnAbsolute(
           this TableLayoutPanel table, int weidht)
            => table.ControlAddIsColumn(null, weidht, SizeType.Absolute);

        public static TableLayoutPanel ControlAddIsColumnPercent(
           this TableLayoutPanel table, Control control, int weidht)
            => table.ControlAddIsColumn(control, weidht, SizeType.Percent);
        
        public static TableLayoutPanel ControlAddIsColumnPercent(
           this TableLayoutPanel table, int weidht)
            => table.ControlAddIsColumn(null, weidht, SizeType.Percent);

        public static TableLayoutPanel ControlAddIsColumnPercent(
           this TableLayoutPanel table, Control control)
            => table.ControlAddIsColumn(control, 10, SizeType.Percent);

        public static TableLayoutPanel ControlAddIsColumnPercent(
           this TableLayoutPanel table)
            => table.ControlAddIsColumn(null, 10, SizeType.Percent);

        public static TableLayoutPanel AddingColumnsStyles(this TableLayoutPanel table, params ColumnStyle[]? columnStyles)
        {
            if (columnStyles == null)
            {
                table.ColumnCount = 1;
                return table;
            }

            columnStyles.ToList().ForEach(c => table.ColumnStyles.Add(c));

            return table;
        }


        public static TableLayoutPanel AddingRowsStyles(this TableLayoutPanel table, params RowStyle[]? rowStyles)
        {
            if (rowStyles == null)
            {
                table.RowCount = 1;
                return table;
            }

            rowStyles.ToList().ForEach(r => table.RowStyles.Add(r));

            return table;
        }
    }
}

