using Logica;

public class ShowNewsDetails : Form
{
    private NewsItem news;

    public ShowNewsDetails(NewsItem news)
    {
        this.news = news;
        Init(news);

        var titleLabel = new Label
        {
            Text = news.Title,
            Font = FactoryElements.Style.TitleFont,
            Dock = DockStyle.Top,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var infoLabel = new Label
        {
            Text = $"{news.Author} • {news.Date:dd.MM.yyyy HH:mm} • {news.Category}",
            Font = new Font(FactoryElements.Style.Font, FontStyle.Italic),
            Dock = DockStyle.Top,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.Gray
        };

        var contentText = new TextBox
        {
            Font = new Font(Font.FontFamily, 12),
            Text = news.Content,
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            BorderStyle = BorderStyle.None,
        };

        var mainTable = FactoryElements
            .CreateTableLayoutPanel()
            .ControlAddIsRowsAbsolute(titleLabel, 30)
            .ControlAddIsRowsAbsolute(infoLabel, 25)
            .ControlAddIsRowsPercent(contentText, 600)
            .ControlAddIsRowsAbsolute(FactoryElements.CreateButton(Attributes.Close, Close), 40);

        Controls.Add(mainTable);
    }

    private void Init(NewsItem news)
    {
        Text = news.Title;
        Size = new Size(600, 800);
        StartPosition = FormStartPosition.CenterParent;
        Padding = new Padding(20);
        FormBorderStyle = FormBorderStyle.FixedDialog;
    }
}