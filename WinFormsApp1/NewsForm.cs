using Logica;

public partial class ViewVisitor : Form
{
    List<NewsItem> allNews = new();

    private void LoadNewsMenuStrip()
    {
        Controls.Clear();

        var titleLabel = new Label
        {
            Text = "Последние новости",
            Font = style.TitleFont,
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill,
            ForeColor = Color.DarkBlue
        };

        var headerPanel = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles(
            new ColumnStyle(SizeType.Percent, 100F),
            new ColumnStyle(SizeType.Absolute, 100))
            .AddingRowsStyles()
            .ControlsAdd(titleLabel, 0, 0);

        var categories = allNews.Select(n => n.Category).Distinct().ToArray();

        displayItems = new Panel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            AutoScroll = true
        };

        var mainTable = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles()
            .AddingRowsStyles(
            new RowStyle(SizeType.Absolute, 25),
            new RowStyle(SizeType.Absolute, 70),
            new RowStyle(SizeType.Percent, 100F))
            .ControlsAdd(menuStrip, 0, 0)
            .ControlsAdd(headerPanel, 0, 1)
            .ControlsAdd(displayItems, 0, 2);

        Controls.Add(mainTable);
        LoadTestNews();
    }

    private TableLayoutPanel CreateNewsCard(NewsItem news, int yPosition)
    {
        var titleLabel = new LinkLabel
        {
            Text = news.Title,
            Font = style.TitleFont,
            LinkColor = Color.DarkBlue,
            Dock = DockStyle.Fill,
            LinkBehavior = LinkBehavior.HoverUnderline
        };
        titleLabel.Click += (s, e) => ShowNewsDetails(news);

        var infoLabel = new Label
        {
            Text = $"{news.Author} • {news.Date:dd.MM.yyyy} • {news.Category}",
            Font = new Font(style.Font, FontStyle.Italic),
            ForeColor = Color.Gray,
            Dock = DockStyle.Fill
        };

        var contentLabel = new Label
        {
            Text = news.Content,
            Font = style.Font,
            ForeColor = Color.Black,
            Dock = DockStyle.Fill
        };

        var tableCard = new TableLayoutPanel {
            Location = new Point(0, yPosition),
            Size = new Size(displayItems.Width - 25, 180),
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(15),
        };

        tableCard
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 25),
                new RowStyle(SizeType.Absolute, 20),
                new RowStyle(SizeType.Absolute, 80))
            .ControlsAdd(titleLabel, 0, 0)
            .ControlsAdd(infoLabel, 0, 1)
            .ControlsAdd(contentLabel, 0, 2);

        return tableCard;
    }

    private void ShowNewsDetails(NewsItem news)
    {
        var detailsForm = new Form
        {
            Text = news.Title,
            Size = new Size(600, 800),
            StartPosition = FormStartPosition.CenterParent,
            Padding = new Padding(20),
            FormBorderStyle = FormBorderStyle.FixedDialog,
        };

        var titleLabel = new Label
        {
            Text = news.Title,
            Font = style.TitleFont,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var infoLabel = new Label
        {
            Text = $"{news.Author} • {news.Date:dd.MM.yyyy HH:mm} • {news.Category}",
            Font = new Font(style.Font, FontStyle.Italic),
            Dock = DockStyle.Top,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.Gray
        };

        var contentText = new TextBox
        {
            Font = new Font(Font.FontFamily ,12),
            Text = news.Content,
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            BorderStyle = BorderStyle.None,
            BackColor = SystemColors.Window
        };

        var closeButton = elementFactory.CreateButton(Attributes.Close);
        closeButton.Dock = DockStyle.Bottom;
        closeButton.Click += (s, e) => detailsForm.Close();

        detailsForm.Controls.Add(contentText);
        detailsForm.Controls.Add(infoLabel);
        detailsForm.Controls.Add(titleLabel);
        detailsForm.Controls.Add(closeButton);

        detailsForm.ShowDialog();
    }

    // Класс для представления новости
    private class NewsItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}

