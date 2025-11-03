using Logica.Extension;
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
            => control == null ? 
                table
                    .ControlAddIsRowsAbsolute(new Panel(), heinght) : 
                table
                    .With(t => t.RowStyles.Add(new RowStyle(SizeType.Absolute, heinght)))
                    .With(t => t.Controls.Add(control, 0, table.RowStyles.Count - 1));
        
        public static TableLayoutPanel ControlAddIsRowsAbsoluteV2(
           this TableLayoutPanel table, Control control, int heinght)
            => control == null ? 
                table
                    .ControlAddIsRowsAbsolute(new Panel(), heinght) : 
                table
                    .With(t => t.RowStyles.Add(new RowStyle(SizeType.Absolute, heinght)))
                    .With(t => t.Controls.Add(control, 
                        t.ColumnStyles.Count == 0 ? 0 : 
                        t.ColumnStyles.Count - 1, 
                        t.RowStyles.Count - 1));
        
        public static TableLayoutPanel ControlAddIsRowsPercent(
           this TableLayoutPanel table, Control? control, int heinght)
            => control == null ? 
                table
                    .ControlAddIsRowsPercent(new Panel(), heinght) : 
                table
                    .With(t => t.RowStyles.Add(new RowStyle(SizeType.Percent, heinght)))
                    .With(t => t.Controls.Add(control, 0, table.RowStyles.Count - 1));
        
        public static TableLayoutPanel ControlAddIsRowsPercentV2(
           this TableLayoutPanel table, Control? control, int heinght)
            => control == null ? 
                table
                    .ControlAddIsRowsPercent(new Panel(), heinght) : 
                table
                    .With(t => t.RowStyles.Add(new RowStyle(SizeType.Percent, heinght)))
                    .With(t => t.Controls.Add(control, 
                        t.ColumnStyles.Count == 0 ? 0 :
                        t.ColumnStyles.Count - 1, 
                        t.RowStyles.Count - 1));
        
        
        public static TableLayoutPanel ControlAddIsColumnAbsolute(
           this TableLayoutPanel table, Control? control, int weidht)
            => control == null ?
                table
                    .ControlAddIsColumnAbsolute(new Panel(), weidht) :
                table
                    .With(t => t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, weidht)))
                    .With(t => t.Controls.Add(control, table.ColumnStyles.Count - 1, 0));

        public static TableLayoutPanel ControlAddIsColumnAbsoluteV2(
           this TableLayoutPanel table, Control control, int weidht)
            => table.ControlAddIsColumn(control, weidht, SizeType.Absolute);

        public static TableLayoutPanel ControlAddIsColumnPercentV2(
           this TableLayoutPanel table, Control control, int weidht)
            => table.ControlAddIsColumn(control, weidht, SizeType.Percent);
        
        public static TableLayoutPanel ControlAddIsColumn(
           this TableLayoutPanel table, Control control, int weidht, SizeType sizeType)
            => control == null ?
                table
                    .ControlAddIsColumnPercent(new Panel(), weidht) :
                table
                    .With(t => t.ColumnStyles.Add(new ColumnStyle(sizeType, weidht)))
                    .With(t => t.Controls.Add(control, 
                        t.ColumnStyles.Count == 0 ? 0 :
                        t.ColumnStyles.Count - 1, 
                        t.RowStyles.Count));

        public static TableLayoutPanel ControlAddIsColumnPercent(
           this TableLayoutPanel table, Control control, int weidht)
            => control == null ?
                table
                    .ControlAddIsColumnPercent(new Panel(), weidht) :
                table
                    .With(t => t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, weidht)))
                    .With(t => t.Controls.Add(control, table.ColumnStyles.Count - 1, 0));
        

        public static TableLayoutPanel AddingColumnsStyles(this TableLayoutPanel table, params ColumnStyle[] columnStyles)
        {
            if (columnStyles == null)
            {
                table.ColumnCount = 1;
                return table;
            }

            columnStyles.ToList().ForEach(c => table.ColumnStyles.Add(c));

            return table;
        }
        

        public static TableLayoutPanel AddingRowsStyles(this TableLayoutPanel table, params RowStyle[] rowStyles)
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

