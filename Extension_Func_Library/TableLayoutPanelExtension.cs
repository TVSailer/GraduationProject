using System.Windows.Forms;

namespace Extension_Func_Library
{
    public static class TableLayoutPanelExtension
    {
        public static TableLayoutPanel ControlAddIsRow(
            this TableLayoutPanel table, Control? control, int heinght, SizeType sizeType)
            => control == null
                ? table
                    .ControlAddIsRow(new Panel(), heinght, sizeType)
                : table
                    .AddingRowsStyles(new RowStyle(sizeType, heinght))
                    .AddControlRow(control);
        
        public static TableLayoutPanel ControlAddIsRow(
            this TableLayoutPanel table, Control? control, RowStyle style)
            => control == null
                ? table
                    .ControlAddIsRow(new Panel(), style)
                : table
                    .AddingRowsStyles(style)
                    .AddControlRow(control);

        private static TableLayoutPanel AddControlRow(this TableLayoutPanel table, Control control)
        {
            table.Controls.Add(control,
                table.ColumnStyles.Count == 0 ? 0 : table.ColumnStyles.Count - 1,
                table.RowStyles.Count - 1);

            return table;
        }

        private static TableLayoutPanel AddControlColumn(this TableLayoutPanel table, Control control)
        {
            table.Controls.Add(control,
                table.ColumnStyles.Count - 1,
                table.RowStyles.Count == 0 ? 0 : table.RowStyles.Count - 1);

            return table;
        }

        public static TableLayoutPanel ControlAddIsRowsAbsolute(
            this TableLayoutPanel table, Control control, int heinght)
            => table.ControlAddIsRow(control, heinght, SizeType.Absolute);

        public static TableLayoutPanel ControlAddIsRowsPercent(
            this TableLayoutPanel table, Control? control)
            => table.ControlAddIsRow(control, 10, SizeType.Percent);

        public static TableLayoutPanel ControlAddIsRowsPercent(
            this TableLayoutPanel table, Control? control, int heingt)
            => table.ControlAddIsRow(control, heingt, SizeType.Percent);

        public static TableLayoutPanel AddingColumnsStyles(this TableLayoutPanel table,
            params ColumnStyle[]? columnStyles)
        {
            if (columnStyles == null)
            {
                table.ColumnCount = 1;
                return table;
            }
            foreach (var columnStyle in columnStyles)
                table.ColumnStyles.Add(new ColumnStyle(columnStyle.SizeType, columnStyle.Width));

            return table;
        }


        public static TableLayoutPanel AddingRowsStyles(this TableLayoutPanel table, params RowStyle[]? rowStyles)
        {
            if (rowStyles == null)
            {
                table.RowCount = 1;
                return table;
            }

            foreach (var rowStyle in rowStyles)
                table.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
            return table;
        }
    }
}