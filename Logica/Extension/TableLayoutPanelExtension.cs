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
    }
}

