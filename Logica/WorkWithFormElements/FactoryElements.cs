using Logica;

public static class FactoryElements
{
    private static BaseStyle style;
    public static BaseStyle Style 
    {
        get
        {
            if (style == null)
                style = new BaseStyle();

            return style;
        }
        set => style = value;
    }

    public static MenuStrip CreateMenuStrip(params ToolStripDropDownItem[] toolStripMenuItems)
    {
        var menuStrip = new MenuStrip();
        foreach (var tool in toolStripMenuItems)
            menuStrip.Items.Add(tool);
        return menuStrip;
    }

    public static ToolStripMenuItem CreateToolStripMenu(string attributeMenu, params string[] attributes)
    {
        var toolStripMenu = new ToolStripMenuItem(attributeMenu);
        foreach (var attribute in attributes)
            toolStripMenu.DropDownItems.Add(attribute);
        return toolStripMenu;
    }

    public static ComboBox CreateComboBox(object text, params object[] attributes)
    {
        var cb = CreateComboBoxBase(text);
        foreach (var attribute in attributes)
            cb.Items.Add(attribute);
        return cb;
    }

    public static CheckedListBox CreateCheckedListBox(params object[] attributes)
    {
        var clb = CreateCheckedListBoxBase();
        foreach (var attribute in attributes)
            clb.Items.Add(attribute);
        return clb;
    }

    public static DataGridView CreateDataGridView(params string[] attributes)
    {
        var dgv = CreateDataGridViewBase();
        foreach (var attribute in attributes)
        {
            dgv.Columns.Add(attribute, attribute);
            dgv.Columns[attribute].ReadOnly = true;
        }
        return dgv;
    }

    public static TableLayoutPanel CreateTableLayoutPanel(int countColum, params int[] heinghs)
    {
        var table = CreateTableLayoutPanel();
        foreach (var heingh in heinghs)
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, heingh));
        for (int i = 0; i < countColum; i++)
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / countColum));
        return table;
    }

    public static TableLayoutPanel CreateTableLayoutPanel(ColumnStyle[] columns, RowStyle[] rows)
    {
        var table = CreateTableLayoutPanel();
        foreach (var row in rows)
            table.RowStyles.Add(row);
        foreach (var column in columns)
            table.ColumnStyles.Add(column);

        return table;
    }


    public static Button CreateButton(string text)
        => new Button()
        {
            Name = text.Replace(" ", "") + "Button",
            Text = text,
            Dock = Style.DockStyle,
            Font = Style.Font,
            BackColor = Style.ButtonBackColor,
            ForeColor = Style.ButtonForeColor,
        };

    public static Button CreateButton<T>(string text, Action<T> action, T obj)
    {
        var button = CreateButton(text);
        button.Click += (send, e) => action?.Invoke(obj);

        return button;
    }
    
    public static Button CreateButton(string text, Action action)
    {
        var button = CreateButton(text);
        button.Click += (send, e) => action?.Invoke();

        return button;
    }
    public static Label CreateLabel(string text)
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
    
    public static Label CreateLabel(string text, ContentAlignment alignment)
        => new Label()
        {
            Name = text.Replace(" ", "") + "Label",
            Text = text,
            Dock = Style.DockStyle,
            Font = Style.Font,
            TextAlign = alignment,
            Height = Style.LabelHeinght,
            Width = Style.LabelWidth,
            BorderStyle = Style.LabelBorderStyle,
            Padding = Style.ControlPadding
        };
    public static DateTimePicker CreateDateTimePicker(string attribute)
        => new DateTimePicker()
        {
            Name = attribute,
            Dock = Style.DockStyle,
            Font = Style.Font,
            Format = Style.DateTimePickerFormat,
            Padding = Style.ControlPadding
        };
    public static LinkLabel CreateLinkLabel(string attribute)
        => new LinkLabel()
        {
            Name = attribute,
            Dock = Style.DockStyle,
            Font = Style.Font,
            Text = attribute,
            Padding = Style.ControlPadding,
            TextAlign = Style.ContentAlignment
        };
    public static TextBox CreateTextBox(string attribute)
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

    public static TextBox CreateTextBox(string attribute, Action<object> action)
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

    public static CheckedListBox CreateCheckedListBoxBase(params object[] attributes)
        => new CheckedListBox()
        {
            Dock = Style.DockStyle,
            Font = Style.Font,
            CheckOnClick = true,
            Padding = Style.ControlPadding
        };
    public static ComboBox CreateComboBoxBase(object selectObject, params object[] attributes)
        => new ComboBox()
        {
            SelectedItem = selectObject,
            Text = selectObject.ToString(),
            Dock = Style.DockStyle,
            Padding = Style.ControlPadding
        };

    public static DataGridView CreateDataGridViewBase(params string[] attributes)
        => new DataGridView()
        {
            Dock = Style.DockStyle,
            Font = Style.Font,
            AutoSizeColumnsMode = Style.DataGridViewAutoSizeColumnsMode,
            EditMode = DataGridViewEditMode.EditProgrammatically,
            SelectionMode = DataGridViewSelectionMode.RowHeaderSelect,
            MultiSelect = false,
            Padding = Style.ControlPadding,
            ScrollBars = ScrollBars.Horizontal
        };

    public static TableLayoutPanel CreateTableLayoutPanel()
        => new TableLayoutPanel()
        {
            Padding = Style.FormPadding,
            Dock = Style.DockStyle,
        };

    public static ToolStripMenuItem CreateToolStripMenu(string attributeMenu, params StripMenuItem[] stripMenuItems)
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

    public static MenuStrip CreateMenuStrip(params ToolStripMenuItem[] toolStripMenuItems)
    {
        var menuStrip = new MenuStrip();
        if (toolStripMenuItems != null)
            foreach (var tool in toolStripMenuItems)
                menuStrip.Items.Add(tool);
        return menuStrip;
    }

    public static List<Label> CreateListLabel(params string[] attributes)
        => CreateControls(CreateLabel, attributes);
    public static List<Button> CreateListButton(params string[] attributes)
        => CreateControls(CreateButton, attributes);
    public static List<TextBox> CreateListTextBox(params string[] attributes)
        => CreateControls(CreateTextBox, attributes);
    public static List<T> CreateControls<T>(Func<string, T> action, params string[] attributes)
    {
        var list = new List<T>();
        foreach (var attribute in attributes)
            list.Add(action(attribute));
        return list;
    }
}
