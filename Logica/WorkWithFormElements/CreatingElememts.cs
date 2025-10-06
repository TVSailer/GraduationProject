namespace Logica
{
    public partial class CreatingElements : BaseCreatingElements
    {
        public CreatingElements(BaseStyle style)
        {
            this.Style = style;
        }

        public override MenuStrip CreateMenuStrip(params string[] attributes)
        {
            var menuStrip = new MenuStrip();
            //foreach (var attribute in attributes)
            //    menuStrip.Items.Add(CreateToolStripMenu(attribute));
            return menuStrip;
        }
        
        public override MenuStrip CreateMenuStrip(params ToolStripDropDownItem[] toolStripMenuItems)
        {
            var menuStrip = new MenuStrip();
            foreach (var tool in toolStripMenuItems)
                menuStrip.Items.Add(tool);
            return menuStrip;
        }

        public override ToolStripMenuItem CreateToolStripMenu(string attributeMenu, params string[] attributes)
        {
            var toolStripMenu = new ToolStripMenuItem(attributeMenu);
            foreach (var attribute in attributes)
                toolStripMenu.DropDownItems.Add(attribute);
            return toolStripMenu;
        }
        
        public override ComboBox CreateComboBox(object text, params object[] attributes)
        {
            var cb = base.CreateComboBox(text);
            foreach (var attribute in attributes)
                cb.Items.Add(attribute);
            return cb;
        }

        public override CheckedListBox CreateCheckedListBox(params object[] attributes)
        {
            var clb = base.CreateCheckedListBox();
            foreach (var attribute in attributes)
                clb.Items.Add(attribute);
            return clb;
        }

        public override DataGridView CreateDataGridView(params string[] attributes)
        {
            var dgv = base.CreateDataGridView();
            foreach (var attribute in attributes)
            {
                dgv.Columns.Add(attribute, attribute);
                dgv.Columns[attribute].ReadOnly = true;
            }
            return dgv;
        }

        public override TableLayoutPanel CreateTableLayoutPanel(int countColum, params int[] heinghs)
        {
            var table = CreateTableLayoutPanel();
            foreach (var heingh in heinghs)
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, heingh));
            for (int i = 0; i < countColum; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / countColum));
            return table;
        }

        public override TableLayoutPanel CreateTableLayoutPanel(ColumnStyle[] columns, RowStyle[] rows)
        {
            var table = CreateTableLayoutPanel();
            foreach (var row in rows)
                table.RowStyles.Add(row);
            foreach (var column in columns)
                table.ColumnStyles.Add(column);

            return table;
        }

        public override List<Label> CreateListLabel(params string[] attributes)
            => CreateControls(CreateLabel, attributes);
        public override List<Button> CreateListButton(params string[] attributes)   
            => CreateControls(CreateButton, attributes);
        public override List<TextBox> CreateListTextBox(params string[] attributes)
            => CreateControls(CreateTextBox, attributes);
        public List<T> CreateControls<T>(Func<string, T> action, params string[] attributes)
        {
            var list = new List<T>();
            foreach (var attribute in attributes)
                list.Add(action(attribute));
            return list;
        }
    }
}

