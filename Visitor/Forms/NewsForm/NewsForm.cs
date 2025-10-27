using DataAccess.Postgres.Models;
using Logica;

public partial class ViewVisitor : Form
{
    List<NewsEntity> allNews = new();

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
    }

    private TableLayoutPanel CreateNewsCard(NewsEntity news, int yPosition)
    {
        var titleLabel = new LinkLabel
        {
            Text = news.Title,
            Font = style.TitleFont,
            LinkColor = Color.DarkBlue,
            Dock = DockStyle.Fill,
            LinkBehavior = LinkBehavior.HoverUnderline
        };
        titleLabel.Click += (s, e) => new ShowNewsDetails(news).ShowDialog();

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
}

