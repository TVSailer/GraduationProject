using System.Reflection;
using Admin.ViewModels.Lesson;
using Logica;
using Font = System.Drawing.Font;


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

    public static Control Control(string nameMethod, object[] parametrs)
    {
        var method = GetMethod(nameMethod);
        var rezult = (Control)method.Invoke(null, parametrs) ?? throw new ArgumentException();
        return rezult;
    }

    public static MethodInfo GetMethod(string name)
    {
        var method = typeof(FactoryElements).GetMethod(name);
        if (method is null) throw new Exception();
        return method;
    }

    public static ToolStripMenuItem CreateToolStripMenu(string attributeMenu, params string[] attributes)
    {
        var toolStripMenu = new ToolStripMenuItem(attributeMenu);
        foreach (var attribute in attributes)
            toolStripMenu.DropDownItems.Add(attribute);
        return toolStripMenu;
    }

    public static ComboBox ComboBox()
    {
        return new ComboBox()
            .With(cb => cb.Dock = DockStyle.Fill)
            .With(cb => cb.DropDownStyle = ComboBoxStyle.DropDownList)
            .With(cb => cb.Font = new Font("Times New Roman", 11, FontStyle.Bold));
    }

    public static ComboBox ComboBox(object[] items)
    {
        return ComboBox()
            .With(cb => cb.Items.AddRange(items));
    }

    public static DateTimePicker DateTimePicker(string custom)
    {
        return new DateTimePicker
        {
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Padding = new Padding(5),
            Format = DateTimePickerFormat.Custom,
            CustomFormat = custom,
            ShowUpDown = true
        };
    }

    public static MaskedTextBox MaskedTextBox(string mask)
    {
        return new MaskedTextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Padding = new Padding(5),
            Mask = mask
        };
    }

    public static LinkLabel LinkLabel(string text, int size)
    {
        return new LinkLabel
        {
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", size, FontStyle.Bold),
            Text = text,
            TextAlign = ContentAlignment.TopLeft,
            LinkColor = Color.DarkBlue,
            LinkBehavior = LinkBehavior.HoverUnderline
        };
    }

    public static LinkLabel LinkLabelTitle(string text, Action actionClick)
    {
        return LinkLabel(text, 18)
            .With(l => l.Click += (s, e) => actionClick?.Invoke());
    }

    public static LinkLabel LinkLabel_10(string text, Action actionClick)
    {
        return LinkLabel(text, 10)
            .With(l => l.Click += (s, e) => actionClick?.Invoke())
            .With(l => l.LinkBehavior = LinkBehavior.AlwaysUnderline);
    }

    public static TextBox TextBox(string placeholderText = "")
    {
        return new TextBox
        {
            Text = "",
            PlaceholderText = placeholderText,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            BorderStyle = BorderStyle.FixedSingle,
            ScrollBars = ScrollBars.Vertical
        };
    }

    public static TextBox TextBox(string placeholderText, bool multiline, bool readOnly)
    {
        return TextBox(placeholderText)
            .With(t => t.ReadOnly = readOnly)
            .With(t => t.Multiline = multiline);
    }

    public static DataGridView DataGridView()
    {
        return new DataGridView
        {
            AutoSize = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AllowUserToAddRows = false,
            ScrollBars = ScrollBars.Both
        };
    }

    public static TableLayoutPanel TableLayoutPanel()
    {
        return new TableLayoutPanel()
            .With(t => t.Padding = new Padding(0))
            .With(t => t.Dock = DockStyle.Fill);
    }

    public static ToolStripMenuItem CreateToolStripMenu(string attributeMenu, params StripMenuItem[] stripMenuItems)
    {
        var toolStripMenu = new ToolStripMenuItem(attributeMenu);

        if (stripMenuItems != null)
            foreach (var strip in stripMenuItems)
            {
                toolStripMenu.DropDownItems.Add(strip.Name);
                toolStripMenu.DropDownItems[^1].Click += (send, e) => strip.Action?.Invoke();
            }

        return toolStripMenu;
    }

    public static Button Button(string text, bool enable = true)
    {
        return new Button()
            .With(c => c.Text = text)
            .With(c => c.Enabled = enable)
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold))
            .With(c => c.BackColor = SystemColors.ButtonFace)
            .With(c => c.ForeColor = SystemColors.ControlText);
    }

    public static Button Button(string text, object context, string dataMember)
    {
        return new Button()
            .With(c => c.Text = text)
            .With(c => c.BackColor = Color.White)
            .With(c => c.DataBindings.Add(new Binding("Command", context, dataMember, true)))
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold));
    }

    public static Button Button(string text, Action action)
    {
        return Button(text, _ => action.Invoke());
    }

    public static Button Button(string text, Action<object?> action, bool enabled = true)
    {
        return new Button()
            .With(c => c.Text = text)
            .With(c => c.Enabled = enabled)
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", 11, FontStyle.Bold))
            .With(c => c.Click += (_, _) => action.Invoke(c));
    }

    public static Button Button(string text, int size, Action action)
    {
        return Button(text, size)
            .With(c => c.Click += (s, e) => action?.Invoke());
    }

    public static Button Button(string text, int size, object context, string dataMember)
    {
        return Button(text, size)
            .With(c => c.DataBindings.Add(new Binding("Command", context, dataMember, true)));
    }

    public static Button Button(string text, int size)
    {
        return new Button()
            .With(c => c.Text = text)
            .With(c => c.Dock = DockStyle.Fill)
            .With(c => c.Font = new Font("Times New Roman", size, FontStyle.Bold));
    }

    public static Label LabelTitle(string text)
    {
        return Label(text)
            .With(l => l.Font = new Font("Times New Roman", 18, FontStyle.Bold))
            .With(l => l.ForeColor = Color.DarkBlue)
            .With(l => l.TextAlign = ContentAlignment.TopCenter);
    }

    public static Label Label_12(string text)
    {
        return Label(text)
            .With(l => l.Font = new Font("Times New Roman", 12, FontStyle.Bold));
    }

    public static Label Label_11(string text)
    {
        return Label(text)
            .With(l => l.Font = new Font("Times New Roman", 11, FontStyle.Bold));
    }

    public static Label Label_10(string text)
    {
        return Label(text)
            .With(l => l.Font = new Font("Times New Roman", 10, FontStyle.Bold));
    }

    public static Label Label_09(string text)
    {
        return Label(text)
            .With(l => l.Font = new Font("Times New Roman", 9, FontStyle.Bold));
    }

    public static Label Label_08(string text)
    {
        return Label(text)
            .With(l => l.Font = new Font("Times New Roman", 8, FontStyle.Bold));
    }

    public static Label Label(string text)
    {
        return new Label()
            .With(l => l.Text = text)
            .With(l => l.Dock = DockStyle.Fill)
            .With(l => l.AutoSize = true)
            .With(l => l.TextAlign = ContentAlignment.TopLeft)
            .With(l => l.BorderStyle = BorderStyle.None)
            .With(l => l.Padding = new Padding(5));
    }

    public static FlowLayoutPanel FlowLayoutPanel()
    {
        return new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10));
    }

    public static PictureBox PictureBox(string imgUrl)
    {
        return new PictureBox()
            .With(pb => pb.Size = new Size(300, 200))
            .With(pb => pb.Margin = new Padding(5))
            .With(pb => pb.SizeMode = PictureBoxSizeMode.Zoom)
            .With(pb => pb.BackColor = Color.Black)
            .With(pb => pb.ImageLocation = imgUrl)
            .With(img => img.MouseDoubleClick += (s, e) => FullSizeImage(imgUrl));
    }

    public static void FullSizeImage(string imgUrl)
    {
        new Form()
            .With(f => f.Text = $"Просмотр изображения: {Path.GetFileName(imgUrl)}")
            .With(f => f.Size = new Size(800, 600))
            .With(f => f.StartPosition = FormStartPosition.CenterParent)
            .With(f => f.BackColor = Color.Black)
            .With(f => f.Controls.Add(
                new PictureBox()
                    .With(pb => pb.Dock = DockStyle.Fill)
                    .With(pb => pb.SizeMode = PictureBoxSizeMode.Zoom)
                    .With(pb => pb.ImageLocation = imgUrl)))
            .ShowDialog();
    }

    public static Control NumericUpDown()
    {
        return new NumericUpDown()
            .With(n => n.Minimum = 1)
            .With(n => n.Maximum = 1000)
            .With(n => n.Value = 50)
            .With(n => n.Font = new Font("Times New Roman", 11))
            .With(n => n.Dock = DockStyle.Fill);
    }

    public static ListBox ListBox()
    {
        return new ListBox()
            .With(l => l.Dock = DockStyle.Fill);
    }
}