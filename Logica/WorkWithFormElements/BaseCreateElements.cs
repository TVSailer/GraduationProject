namespace Logica
{
    public abstract partial class BaseCreatingElements
    {
        protected virtual BaseStyle Style { get; set; }
        
        public virtual Button CreateButton(string text)
            => new Button() 
            { 
                Name = text.Replace(" ", "") + "Button", 
                Text = text,
                Dock = Style.DockStyle,
                Font = Style.Font,
                BackColor = Style.ButtonBackColor,
                ForeColor = Style.ButtonForeColor,
                Height = Style.ButtonHeight,
                FlatStyle = Style.ButtonFlatStyle,
                Padding = Style.ControlPadding,
            };
        
        public virtual Button CreateButton<T>(string text, Action<T> action, T obj)
        {
            var button = new Button() 
            { 
                Name = text.Replace(" ", "") + "Button", 
                Text = text,
                Font = Style.Font,
                Dock = Style.DockStyle,
                BackColor = Style.ButtonBackColor,
                ForeColor = Style.ButtonForeColor,
            };

            button.Click += (send, e) => action.Invoke(obj);

            return button;
        }
        public virtual Label CreateLabel(string text)
            => new Label() 
            {
                Name = text.Replace(" ", "") + "Label",
                Text = text,
                Dock = Style.DockStyle,
                Font = Style.Font,
                TextAlign = Style.ContentAlignment,
                Height = Style.LabelHeinght,
                Width = Style.LabelWidth,
                BorderStyle = Style.LabelBorderStyle,
                Padding = Style.ControlPadding
            };
        public virtual DateTimePicker CreateDateTimePicker(string attribute)
            => new DateTimePicker()
            {
                Name = attribute,
                Dock = Style.DockStyle,
                Font = Style.Font,
                Format = Style.DateTimePickerFormat,
                Padding = Style.ControlPadding
            };
        public virtual LinkLabel CreateLinkLabel(string attribute)
            => new LinkLabel()
            {
                Name = attribute,
                Dock = Style.DockStyle,
                Font = Style.Font,
                Text = attribute,
                Padding = Style.ControlPadding,
                TextAlign = Style.ContentAlignment
            };
        public virtual TextBox CreateTextBox(string attribute)
            => new TextBox()
            {
                Name = attribute.Replace(" ", "") + "TextBox",
                Dock = Style.DockStyle,
                Font = Style.Font,
                Height = Style.TextBoxHeight,
                Width = Style.TextBoxWidth,
                BorderStyle = Style.TextBoxBorderStyle,
                Padding = Style.ControlPadding
            };
        
        public virtual TextBox CreateTextBox(string attribute, Action<object> action)
        {
            var tb = new TextBox()
            {
                Name = attribute.Replace(" ", "") + "TextBox",
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            tb.TextChanged += (send, e) => action.Invoke(tb.Text);

            return tb;
        }

        public virtual CheckedListBox CreateCheckedListBox(params object[] attributes)
            => new CheckedListBox()
            {
                Dock = Style.DockStyle,
                Font = Style.Font,
                CheckOnClick = true,
                Padding = Style.ControlPadding
            };
        public virtual ComboBox CreateComboBox(object selectObject, params object[] attributes)
            => new ComboBox()
            {
                SelectedItem = selectObject,
                Text = selectObject.ToString(),
                Dock = Style.DockStyle,
                Padding = Style.ControlPadding
            };

        public virtual DataGridView CreateDataGridView(params string[] attributes)
            => new DataGridView()
            {
                Dock = Style.DockStyle,
                Font = Style.Font,
                AutoSizeColumnsMode = Style.DataGridViewAutoSizeColumnsMode,
                EditMode = DataGridViewEditMode.EditProgrammatically,
                SelectionMode = DataGridViewSelectionMode.RowHeaderSelect,
                MultiSelect = false,
                Padding = Style.ControlPadding
            };

        public virtual TableLayoutPanel CreateTableLayoutPanel()
            => new TableLayoutPanel()
            {
                Padding = Style.FormPadding,
                Dock = Style.DockStyle,
            };



        public abstract TableLayoutPanel CreateTableLayoutPanel(ColumnStyle[] columns, RowStyle[] rows);

        public virtual ToolStripMenuItem CreateToolStripMenu(string attributeMenu, params StripMenuItem[] stripMenuItems)
        {
            var toolStripMenu = new ToolStripMenuItem(attributeMenu);

            if (stripMenuItems != null)
            {
                foreach (var strip in stripMenuItems)
                {
                    toolStripMenu.DropDownItems.Add(strip.Name);
                    toolStripMenu.DropDownItems[^1].Click += (send, e) => strip.Action?.Invoke();
                }
            }
            return toolStripMenu;
        }

        public virtual MenuStrip CreateMenuStrip(params ToolStripMenuItem[] toolStripMenuItems)
        {
            var menuStrip = new MenuStrip();
            if (toolStripMenuItems != null)
                foreach (var tool in toolStripMenuItems)
                    menuStrip.Items.Add(tool);
            return menuStrip;
        }

        public abstract ToolStripMenuItem CreateToolStripMenu(string nameMenu, params string[] attributes);
        public abstract MenuStrip CreateMenuStrip(params ToolStripDropDownItem[] toolStripDropDownItem);
        public abstract MenuStrip CreateMenuStrip(params string[] attributes);
        public abstract List<TextBox> CreateListTextBox(params string[] attributes);
        public abstract List<Label> CreateListLabel(params string[] attributes);
        public abstract List<Button> CreateListButton(params string[] attributes);
        public abstract TableLayoutPanel CreateTableLayoutPanel(int countColum, params int[] heinghsRows);
    }
}
