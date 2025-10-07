using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Forms;

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
            this TableLayoutPanel table, Control heading, int column, int row) 
        {
            table.Controls.Add(heading, column, row);
            return table;
        }

        public static TableLayoutPanel ControlsAdd(
           this TableLayoutPanel table, Control heading, int column, int row, int valueColumnSpan, int valueRowSpan)
        {
            table.Controls.Add(heading, column, row);
            if (valueColumnSpan > 1) table.SetColumnSpan(heading, valueColumnSpan);
            if (valueRowSpan > 1) table.SetRowSpan(heading, valueRowSpan);

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

