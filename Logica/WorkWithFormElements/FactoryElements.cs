using Logica;
using Logica.Extension;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks.Dataflow;
using Font = System.Drawing.Font;
using Admin.ViewModels.Lesson;



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

    public static ComboBox ComboBox()
        => new ComboBox()
        .With(cb => cb.Dock = DockStyle.Fill);

    public static CheckedListBox CheckedListBox(params object[] attributes)
    {
        var clb = CheckedListBoxBase();
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

    public static DateTimePicker DateTimePicker()
        => new DateTimePicker()
        {
            Text = DateTime.Now.ToString(),
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Padding = new Padding(5)

        };
    public static LinkLabel CreateLinkLabel(string attribute)
        => new LinkLabel()
        {
            Name = attribute,
            Dock = Style.DockStyle,
            Font = Style.Font,
            Text = attribute,
            Padding = Style.ControlPadding,
            TextAlign = Style.ContentAlignment,
            Height = Style.LabelHeinght,
            Width = Style.LabelWidth,
            BorderStyle = Style.LabelBorderStyle,
        };
    
    
    public static LinkLabel LinkLabel(string text, int size)
        => new LinkLabel()
        {
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", size, FontStyle.Bold),
            Text = text,
            TextAlign = ContentAlignment.TopLeft,
            LinkColor = Color.DarkBlue,
            LinkBehavior = LinkBehavior.HoverUnderline,
        };
    
    public static LinkLabel LinkLabelTitle(string text, Action actionClick)
        => LinkLabel(text, 18)
        .With(l => l.Click += (s, e) => actionClick?.Invoke());

    public static LinkLabel LinkLabel_10(string text, Action actionClick)
        => LinkLabel(text, 10)
        .With(l => l.Click += (s, e) => actionClick?.Invoke())
        .With(l => l.LinkBehavior = LinkBehavior.AlwaysUnderline);

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

    public static TextBox TextBox(string placeholderText)
        => new TextBox()
        {
            PlaceholderText = placeholderText,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            BorderStyle = BorderStyle.FixedSingle,
            ScrollBars = ScrollBars.Vertical,
        };

    public static TextBox TextBoxMultiline(string placeholderText)
        => new TextBox()
        {
            PlaceholderText = placeholderText,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            BorderStyle = BorderStyle.FixedSingle,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
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

    public static CheckedListBox CheckedListBoxBase(params object[] attributes)
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

    public static TableLayoutPanel TableLayoutPanel()
        => new TableLayoutPanel()
            .With(t => t.Padding = new Padding(10))
            .With(t => t.Dock = DockStyle.Fill);

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

    public static Button Button(string text)
        => new Button()
            .With(c => c.Text = text)
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold))
            .With(c => c.BackColor = SystemColors.ButtonFace)
            .With(c => c.ForeColor = SystemColors.ControlText);

    public static Button Button(string text, object context, string dataMember)
        => new Button()
            .With(c => c.Text = text)
            .With(c => c.BackColor = Color.White)
            .With(c => c.DataBindings.Add(new Binding("Command", context, dataMember, true)))
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold));
    
    public static Button Button(ButtonInfoAttribute buttonInfo, object context)
        => new Button()
            .With(c => c.Text = buttonInfo.Text)
            .With(c => c.BackColor = Color.White)
            .With(c => c.DataBindings.Add(new Binding("Command", context, buttonInfo.ButtonName, true)))
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold));

    public static Button Button(string text, Action action)
        => new Button()
            .With(c => c.Text = text)
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold))
            .With(c => c.Click += (s, e) => action?.Invoke());
    
    public static Button Button(string text, int size, Action action)
        => Button(text, size)
            .With(c => c.Click += (s, e) => action?.Invoke());

    public static Button Button(string text, int size, object context, string dataMember)
        => Button(text, size)
            .With(c => c.DataBindings.Add(new Binding("Command", context, dataMember, true)));

    public static Button Button(string text, int size)
        => new Button()
            .With(c => c.Text = text)
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", size, FontStyle.Bold));

    public static Label LabelTitle(string text)
        => Label(text)
            .With(l => l.Font = new Font("Times New Roman", 18, FontStyle.Bold))
            .With(l => l.ForeColor = Color.DarkBlue)
            .With(l => l.TextAlign = ContentAlignment.TopCenter);

    public static Label Label_12(string text)
        => Label(text)
            .With(l => l.Font = new Font("Times New Roman", 12, FontStyle.Bold));

    public static Label Label_11(string text)
        => Label(text)
            .With(l => l.Font = new Font("Times New Roman", 11, FontStyle.Bold));

    public static Label Label_10(string text)
        => Label(text)
            .With(l => l.Font = new Font("Times New Roman", 10, FontStyle.Bold));
    public static Label Label_09(string text)
        => Label(text)
            .With(l => l.Font = new Font("Times New Roman", 9, FontStyle.Bold));
    public static Label Label_08(string text)
        => Label(text)
            .With(l => l.Font = new Font("Times New Roman", 8, FontStyle.Bold));

    public static Label Label(string text)
        => new Label()
            .With(l => l.Text = text)
            .With(l => l.Dock = DockStyle.Fill)
            .With(l => l.Height = 40)
            .With(l => l.TextAlign = ContentAlignment.TopLeft)
            .With(l => l.BorderStyle = BorderStyle.None)
            .With(l => l.Padding = new Padding(5));
    
    public static FlowLayoutPanel FlowLayoutPanel()
        => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10));

    public static PictureBox PictureBox(string imgUrl)
        => new PictureBox()
            .With(pb => pb.Size = new Size(300, 200))
            .With(pb => pb.Margin = new Padding(5))
            .With(pb => pb.SizeMode = PictureBoxSizeMode.Zoom)
            .With(pb => pb.BackColor = Color.Black)
            .With(pb => pb.ImageLocation = imgUrl)
            .With(img => img.MouseDoubleClick += (s, e) => FullSizeImage(imgUrl));

    public static void FullSizeImage(string imgUrl)
           => new Form()
               .With(f => f.Text = $"Просмотр изображения: {System.IO.Path.GetFileName(imgUrl)}")
               .With(f => f.Size = new Size(800, 600))
               .With(f => f.StartPosition = FormStartPosition.CenterParent)
               .With(f => f.BackColor = Color.Black)
               .With(f => f.Controls.Add(
                   new PictureBox()
                   .With(pb => pb.Dock = DockStyle.Fill)
                   .With(pb => pb.SizeMode = PictureBoxSizeMode.Zoom)
                   .With(pb => pb.ImageLocation = imgUrl)))
               .ShowDialog();

    public static Control NumericUpDown()
        => new NumericUpDown()
            .With(n => n.Minimum = 1)
            .With(n => n.Maximum = 1000)
            .With(n => n.Value = 50)
            .With(n => n.Font = new Font("Times New Roman", 11))
            .With(n => n.Dock = DockStyle.Fill);

    public static ListBox ListBox()
        => new ListBox()
        .With(l => l.Dock = DockStyle.Fill);
}
